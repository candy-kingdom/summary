using Summary.Extensions;

namespace Summary;

/// <summary>
///     A <see cref="DocMember" /> that represents a documented method in the parsed source code.
/// </summary>
/// <inheritdoc cref="DocMember" />
public record DocMethod(
    string FullyQualifiedName,
    string Name,
    string Declaration,
    AccessModifier Access,
    DocComment Comment,
    DocType? DeclaringType,
    DocParam[] Params,
    DocTypeParam[] TypeParams) : DocMember(FullyQualifiedName, Name, Declaration, Access, Comment, DeclaringType)
{
    public string SignatureWithoutParams => $"{FullyQualifiedName}{TypeParamsSignature}";

    public string Signature => $"{SignatureWithoutParams}{ParamsSignature}";

    private string TypeParamsSignature =>
        TypeParams.Select(x => x.Name).Separated(",").Wrap("{", "}");

    private string ParamsSignature =>
        $"({Params.Select(x => x.Type?.FullName).Separated(",")})";
}