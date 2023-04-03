namespace Summary;

/// <summary>
///     A document parsed from the source code or an assembly.
/// </summary>
/// <param name="Members">The sequence of members this doc contains.</param>
public record Doc(DocMember[] Members)
{
    /// <summary>
    ///     An empty document.
    /// </summary>
    public static readonly Doc Empty = new(Array.Empty<DocMember>());

    /// <summary>
    ///     Merges two documents together returning the new merged document.
    /// </summary>
    /// <param name="a">The first document to merge.</param>
    /// <param name="b">The second document to merge.</param>
    public static Doc Merge(Doc a, Doc b) => new(a.Members.Concat(b.Members).ToArray());

    /// <summary>
    ///     A type declaration that matches the specified type.
    /// </summary>
    public DocTypeDeclaration? Declaration(DocType? type) =>
        type is null ? null : Members.OfType<DocTypeDeclaration>().FirstOrDefault(x => x.Name == type.Name);
}