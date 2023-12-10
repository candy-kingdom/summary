namespace Summary.Pipes.IO;

/// <summary>
///     A <see cref="IPipe{I,O}"/> that searches specified directory (recursively) for files that match specified pattern.
/// </summary>
public class ScanPipe(string[] sources, string pattern) : IPipe<Unit, Source[]>
{
    /// <inheritdoc />
    public async Task<Source[]> Run(Unit _)
    {
        // TODO: Consider refactoring this into more proper solution (@j.light).
        if (sources is [var root] && File.Exists(root))
            return new[] { await Source.Read(Path.GetFullPath(root)).ConfigureAwait(false) };

        var tasks = sources.SelectMany(x =>
            Directory
                .EnumerateFiles(x, pattern, SearchOption.AllDirectories)
                .Select(y => Source.Read(Path.GetFullPath(y))));

        return await Task.WhenAll(tasks).ConfigureAwait(false);
    }
}