namespace Doc.Net.Core;

/// <summary>
///     A document parsed from the source code or an assembly.
/// </summary>
/// <param name="Members">The sequence of members this doc contains.</param>
public record Document(DocMember[] Members)
{
    /// <summary>
    ///     Merges two documents together returning the new merged document.
    /// </summary>
    /// <param name="a">The first document to merge.</param>
    /// <param name="b">The second document to merge.</param>
    public static Document Merge(Document a, Document b) => new(a.Members.Concat(b.Members).ToArray());
}