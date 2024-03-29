﻿namespace Summary;

/// <summary>
///     A <see cref="DocCommentNode"/> that represents the link to other member (e.g. <c>&lt;see cref="SomeMember"/&gt;</c>).
/// </summary>
/// <param name="Value">The name of the member the link links to.</param>
/// <param name="Member">The doc member the link references to.</param>
/// TODO: Should the link contain a `DocMember` instead of a string?
public record DocCommentLink(DocMember? Member, string Value) : DocCommentNode;