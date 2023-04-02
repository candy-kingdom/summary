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
    ///     A nested &lt;param&gt; documentation element that has the specified name.
    /// </summary>
    /// <param name="name">The name of the parameter to search inside the comment.</param>
    public DocCommentElement? Param(string name) =>
        Element("param", name);

    /// <summary>
    ///     A nested &lt;typeparam&gt; documentation element that has the specified name.
    /// </summary>
    /// <param name="name">The name of the parameter to search inside the comment.</param>
    public DocCommentElement? TypeParam(string name) =>
        Element("typeparam", name);

    /// <summary>
    ///     A nested documentation element that has the specified name (e.g. `summary`, `remarks`, etc.).
    /// </summary>
    /// <param name="tag">The name of the element tag to search inside the comment.</param>
    /// <param name="name">The value of the `name` attribute of the tag.</param>
    public DocCommentElement? Element(string tag, string name) =>
        Element(x => x.Name == tag && x.Attribute("name")?.Value == name);

    /// <summary>
    ///     A nested documentation element that has the specified name (e.g. `summary`, `remarks`, etc.).
    /// </summary>
    /// <param name="tag">The name of the element tag to search inside the comment.</param>
    public DocCommentElement? Element(string tag) =>
        Element(x => x.Name == tag);

    /// <summary>
    ///     A nested documentation element that matches the specified predicate `p`.
    /// </summary>
    /// <param name="p">The predicate to apply on each nested documentation element.</param>
    public DocCommentElement? Element(Func<DocCommentElement, bool> p) =>
        Nodes.OfType<DocCommentElement>().FirstOrDefault(p);
}