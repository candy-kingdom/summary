namespace Summary.Pipes.IO;

/// <summary>
///     Cleans up a given directory by deleting and re-creating it.
/// </summary>
public class CleanupDirPipe<I> : IPipe<I, I>
{
    private readonly string _root;

    public CleanupDirPipe(string root) =>
        _root = root;

    public Task<I> Run(I input)
    {
        if (Directory.Exists(_root))
            Directory.Delete(_root, recursive: true);

        Directory.CreateDirectory(_root);

        return Task.FromResult(input);
    }
}