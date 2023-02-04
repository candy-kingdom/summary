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
    ///     A nested documentation element that has the specified name (e.g. `summary`, `remarks`, etc.).
    /// </summary>
    /// <param name="tag">The name of the element tag to search inside the comment.</param>
    public DocCommentElement? Element(string tag) =>
        Nodes.OfType<DocCommentElement>().FirstOrDefault(x => x.Name == tag);

    /// <summary>
    ///     A nested documentation element that has the specified name (e.g. `summary`, `remarks`, etc.).
    /// </summary>
    /// <param name="tag">The name of the element tag to search inside the comment.</param>
    /// <param name="name">The value of `name` attribute of the tag.</param>
    public DocCommentElement? Element(string tag, string name) =>
        Nodes.OfType<DocCommentElement>().FirstOrDefault(x => x.Name == tag && x.Attribute("name")?.Value == name);

    /// <summary>
    ///     A nested &lt;param&gt; documentation element that has the specified name.
    /// </summary>
    /// <param name="name">The name of the parameter to search inside the comment.</param>
    public DocCommentElement? Param(string name) =>
        Nodes
            .OfType<DocCommentElement>()
            .FirstOrDefault(x => x.Name == "param" && x.Attribute("name")?.Value == name);
}