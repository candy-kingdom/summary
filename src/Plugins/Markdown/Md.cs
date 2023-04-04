namespace Summary.Markdown;

/// <summary>
///     A Markdown document file.
/// </summary>
/// <param name="Name">The name of the document file.</param>
/// <param name="Content">The content of the document document.</param>
public record Md(string Name, string Content);