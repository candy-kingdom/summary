namespace Summary.Pipes.IO;

/// <summary>
///     A <see cref="IPipe{I,O}" /> that saves the input to the file.
/// </summary>
public class SavePipe<I>(string root, Func<I, (string Path, string Content)> file) : IPipe<I, Unit>
{
    /// <inheritdoc />
    public async Task<Unit> Run(I input)
    {
        var (path, content) = file(input);

        await File.WriteAllTextAsync(Path.Combine(root, path), content).ConfigureAwait(continueOnCapturedContext: false);

        return Unit.Value;
    }
}