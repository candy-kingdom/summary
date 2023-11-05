using Summary.Extensions;

namespace Summary;

/// <summary>
///     A <see cref="DocMember" /> that represents a documented method in the parsed source code.
/// </summary>
public record DocMethod : DocMember
{
    /// <summary>
    ///     The type parameters of the method.
    /// </summary>
    public required DocTypeParam[] TypeParams { get; init; }

    /// <summary>
    ///     The parameters of the method.
    /// </summary>
    public required DocParam[] Params { get; init; }

    /// <summary>
    ///     Whether this method represents a delegate.
    /// </summary>
    public required bool Delegate { get; init; } = false;

    /// <summary>
    ///     The signature of the method without parameters in link format (e.g., `Sum{T}`).
    /// </summary>
    public string SignatureWithoutParams => $"{FullyQualifiedName}{TypeParamsSignature}";

    /// <summary>
    ///     The signature of the method in link format (e.g., `Sum{T}(T, T)`).
    /// </summary>
    public string Signature => $"{SignatureWithoutParams}{ParamsSignature}";

    private string TypeParamsSignature =>
        TypeParams.Select(x => x.Name).Separated(",").Surround("{", "}");

    private string ParamsSignature =>
        $"({Params.Select(x => x.Type?.FullName).Separated(",")})";
}