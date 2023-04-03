using Summary.Extensions;

namespace Summary;

/// <summary>
///     A member of the generated document (e.g. type, field, property, method, etc.).
/// </summary>
/// <param name="Name">The name of the member (e.g. `public int Field` has name `Field`).</param>
/// <param name="Declaration">
///     The code-snippet that contains the full declaration of the member
///     (e.g. `public int Field` is a declaration of the field member `Field`).
/// </param>
/// <param name="Access">The access modifier of the member.</param>
/// <param name="Comment">The documentation comment of the member (can be empty).</param>
public record DocMember(string Name, string Declaration, AccessModifier Access, DocComment Comment)
{
    public bool MatchesCref(string cref) => Cref.StartsWith(cref);

    private string Cref => this switch
    {
        DocMethod method => $"{method.Name}{TypeParams(method)}{Params(method)}",
        DocDelegate @delegate => $"{@delegate.Name}{TypeParams(@delegate)}{Params(@delegate)}",

        _ => Name,
    };

    private static string TypeParams(DocMethod x) =>
        x.TypeParams.Select(x => x.Name).Separated(with: ",").Wrap("{", "}");

    private static string TypeParams(DocDelegate x) =>
        x.TypeParams.Select(x => x.Name).Separated(with: ",").Wrap("{", "}");

    private static string Params(DocMethod x) =>
        $"({x.Params.Select(x => x.Type?.FullName).Separated(with: ",")})";

    private static string Params(DocDelegate x) =>
        $"({x.Params.Select(x => x.Type?.FullName).Separated(with: ",")})";
}