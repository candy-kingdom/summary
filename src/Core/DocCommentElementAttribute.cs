namespace Summary;

/// <summary>
///     An XML-documentation attribute (e.g. `name` in `param`, etc.).
/// </summary>
/// <param name="Name">The name of the attribute (e.g. `name`, `cref`, etc.)</param>
/// <param name="Value">The value of the attribute (e.g. the actual name in `name` attribute).</param>
public record DocCommentElementAttribute(string Name, string Value);