namespace Summary;

/// <summary>
///     A parameter of a <see cref="DocMethod"/>.
/// </summary>
/// <param name="Type">The type of the parameter.</param>
/// <param name="Name">The name of the parameter.</param>
/// <param name="Comment">The comment of the parameter (i.e. `&lt;param&gt;` tag).</param>
public record DocParam(string Type, string Name, DocComment Comment);