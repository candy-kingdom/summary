namespace Summary.Pipes.IO;

/// <summary>
///     A <see cref="IPipe{I,O}"/> that searches specified directory (recursively) for files that match specified pattern.
/// </summary>
public class ScanDirectoryPipe : IPipe<Unit, string[]>
{
    private readonly string[] _sources;
    private readonly string _pattern;

    public ScanDirectoryPipe(string[] sources, string pattern)
    {
        _sources = sources;
        _pattern = pattern;
    }

    public async Task<string[]> Run(Unit _)
    {
        // TODO: Consider refactoring this into more proper solution (@j.light).
        if (_sources is [var root] && File.Exists(root))
            return new[] { await File.ReadAllTextAsync(root) };

        var tasks = _sources
            .SelectMany(x =>
                Directory
                    .EnumerateFiles(x, _pattern, SearchOption.AllDirectories)
                    .Select(x => File.ReadAllTextAsync(x)));

        return await Task.WhenAll(tasks).ConfigureAwait(false);
    }
}