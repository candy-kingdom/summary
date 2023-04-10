namespace Summary.Pipes.IO;

/// <summary>
///     A <see cref="IPipe{I,O}"/> that saves the input to the file.
/// </summary>
public class SavePipe<I> : IPipe<I, Unit>
{
    private readonly string _root;
    private readonly Func<I, (string Path, string Content)> _file;

    public SavePipe(string root, Func<I, (string Path, string Content)> file)
    {
        _root = root;
        _file = file;
    }

    public async Task<Unit> Run(I input)
    {
        if (Directory.Exists(_root))
            Directory.Delete(_root, recursive: true);

        Directory.CreateDirectory(_root);

        var (path, content) = _file(input);

        await File.WriteAllTextAsync(Path.Combine(_root, path), content).ConfigureAwait(false);

        return Unit.Value;
    }
}