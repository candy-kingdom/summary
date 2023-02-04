namespace Summary;

/// <summary>
///     A type parameter of a <see cref="DocMember"/>.
/// </summary>
/// <param name="Name">The name of the parameter.</param>
/// <param name="Comment">The comment of the parameter (i.e. `&lt;typeparam&gt;` tag).</param>
public record DocTypeParam(string Name, DocComment Comment);