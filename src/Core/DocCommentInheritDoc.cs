namespace Summary;

/// <summary>
///     A <see cref="DocCommentNode" /> that inherits documentation from another member
///     (<c>&lt;inheritdoc&gt;</c>).
/// </summary>
/// <param name="Cref">An optional link to the member the documentation should be inherited from.</param>
public record DocCommentInheritDoc(string? Cref) : DocCommentNode;