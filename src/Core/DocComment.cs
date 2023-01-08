namespace Summary;

/// <summary>
///     An documentation comment parsed from the source code.
/// </summary>
/// <param name="Nodes">The sequence of nodes this comment consists of (e.g. `summary`, `remarks`, etc.).</param>
public record DocComment(DocCommentNode[] Nodes)
{
    /// <summary>
    ///     An empty documentation comment.
    /// </summary>
    public static readonly DocComment Empty = new(Array.Empty<DocCommentNode>());

    /// <summary>
    ///     A nested documentation element that with the specified name (e.g. `summary`, `remarks`, etc.).
    /// </summary>
    /// <param name="name">The name of the element to search inside the comment.</param>
    public DocCommentElement? Element(string name) =>
        Nodes.OfType<DocCommentElement>().FirstOrDefault(x => x.Name == name);
}