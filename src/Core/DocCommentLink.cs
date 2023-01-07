namespace Doc.Net.Core;

/// <summary>
///     A <see cref="DocCommentNode"/> that represents the link to other member (e.g. `&lt;see cref="SomeMember"/&gt;`).
/// </summary>
/// <param name="Value">The name of the member the link links to.</param>
/// TODO: Should the link contain a `DocMember` instead of a string?
public record DocCommentLink(string Value) : DocCommentNode;