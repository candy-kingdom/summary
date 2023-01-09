namespace Summary.Pipes.IO;

/// <summary>
///     A <see cref="IPipe{I,O}"/> that searches specified directory (recursively) for files that match specified pattern.
/// </summary>
public class ScanDirectoryPipe : IPipe<Unit, string[]>
{
    private readonly string _root;
    private readonly string _pattern;

    public ScanDirectoryPipe(string root, string pattern)
    {
        _root = root;
        _pattern = pattern;
    }

    public async Task<string[]> Run(Unit _)
    {
        var tasks = Directory
            .EnumerateFiles(_root, _pattern, SearchOption.AllDirectories)
            .Select(x => File.ReadAllTextAsync(x));

        return await Task.WhenAll(tasks).ConfigureAwait(false);
    }
}