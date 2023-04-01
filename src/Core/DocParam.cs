namespace Summary;

/// <summary>
///     A parameter of a <see cref="DocMethod"/>.
/// </summary>
/// <param name="Type">The type of the parameter.</param>
/// <param name="Name">The name of the parameter.</param>
public record DocParam(DocType? Type, string Name)
{
    /// <summary>
    ///     The comment of the parameter (i.e., `&lt;param&gt;` tag).
    /// </summary>
    public DocCommentElement? Comment(DocMember parent) =>
        parent.Comment.Element("param", Name);
}