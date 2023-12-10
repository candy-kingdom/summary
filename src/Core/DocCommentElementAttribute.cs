namespace Summary;

/// <summary>
///     An XML-documentation attribute (e.g. <c>name</c> in <c>param</c>, etc.).
/// </summary>
/// <param name="Name">The name of the attribute (e.g. <c>name</c>, <c>cref</c>, etc.)</param>
/// <param name="Value">The value of the attribute (e.g. the actual name in <c>name</c> attribute).</param>
public record DocCommentElementAttribute(string Name, string Value);