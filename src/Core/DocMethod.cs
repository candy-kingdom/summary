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
    ///     The full signature of the method that includes both type parameters and regular parameters
    ///     (e.g., <c>"Method&lt;T1, T2&gt;(int, short)"</c>).
    /// </summary>
    public string Signature =>
        $"{Name}({Params.Select(x => x.Type?.FullName).Separated(", ")})";

    /// <summary>
    ///     The full signature of the method that includes both type parameters and regular parameters
    ///     (e.g., <c>"Method&lt;T1, T2&gt;(int, short)"</c>).
    /// </summary>
    public string FullyQualifiedSignature =>
        $"{FullyQualifiedName}({Params.Select(x => x.Type?.FullName).Separated(", ")})";
}