namespace Summary;

/// <summary>
///     A <see cref="DocCommentNode"/> that represents the reference to a parameter (`&lt;paramref&gt;`).
/// </summary>
/// <param name="Value">The name of the parameter .</param>
public record DocCommentParamRef(string Value) : DocCommentNode;