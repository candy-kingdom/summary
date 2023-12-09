namespace Summary.Pipes.IO;

/// <summary>
///     Cleans up a given directory by deleting and re-creating it.
/// </summary>
public class CleanupDirPipe<I>(string root) : IPipe<I, I>
{
    public Task<I> Run(I input)
    {
        if (Directory.Exists(root))
            Directory.Delete(root, recursive: true);

        Directory.CreateDirectory(root);

        return Task.FromResult(input);
    }
}