namespace Summary.Pipes.IO;

/// <summary>
///     A <see cref="IPipe{I,O}"/> that searches specified directory (recursively) for files that match specified pattern.
/// </summary>
public class ScanPipe(string[] sources, string pattern) : IPipe<Unit, string[]>
{
    public async Task<string[]> Run(Unit _)
    {
        // TODO: Consider refactoring this into more proper solution (@j.light).
        if (sources is [var root] && File.Exists(root))
            return new[] { await File.ReadAllTextAsync(root) };

        var tasks = sources
            .SelectMany(x =>
                Directory
                    .EnumerateFiles(x, pattern, SearchOption.AllDirectories)
                    .Select(x => File.ReadAllTextAsync(x)));

        return await Task.WhenAll(tasks).ConfigureAwait(false);
    }
}