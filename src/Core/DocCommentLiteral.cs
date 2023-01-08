namespace Summary;

/// <summary>
///     A <see cref="DocCommentNode"/> that represents a literal value (e.g. text, space, newline character, etc.).
/// </summary>
/// <param name="Value">The value of the literal.</param>
/// <remarks>
///     Literals are simple tokens that are parsed as text.
/// </remarks>
public record DocCommentLiteral(string Value) : DocCommentNode;