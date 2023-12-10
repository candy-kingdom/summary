namespace Summary;

/// <summary>
///     A type parameter of a <see cref="DocMember"/>.
/// </summary>
/// <param name="Name">The name of the parameter.</param>
public record DocTypeParam(string Name)
{
    /// <summary>
    ///     The comment of the parameter (i.e., <c>&lt;typeparam&gt;</c> tag).
    /// </summary>
    public DocCommentElement? Comment(DocMember parent) =>
        parent.Comment.TypeParam(Name);
}