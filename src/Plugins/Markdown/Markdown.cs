namespace Net.Core.Markdown;

/// <summary>
///     A markdown document file.
/// </summary>
/// <param name="Name">The name of the document file.</param>
/// <param name="Content">The content of the document document.</param>
public record Markdown(string Name, string Content);