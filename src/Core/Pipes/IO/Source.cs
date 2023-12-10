namespace Summary.Pipes.IO;

/// <summary>
///     A text file with source code.
/// </summary>
/// <param name="Text">The text file content.</param>
/// <param name="Path">The path to the file.</param>
public record Source(string Text, string? Path = null)
{
    /// <summary>
    ///     Reads source code from the specified file.
    /// </summary>
    public static async Task<Source> Read(string path, CancellationToken token = default) =>
        new(await File.ReadAllTextAsync(path, token).ConfigureAwait(false), path);
}