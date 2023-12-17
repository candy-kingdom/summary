using Summary.Extensions;

namespace Summary;

/// <summary>
///     A simple type (e.g. <c>int</c>, <c>string</c>, <c>List&lt;int&gt;</c>, etc.).
/// </summary>
/// <param name="Name">The name of the type (without generic arguments).</param>
/// <param name="TypeParams">The generic parameters of this type (if it's generic).</param>
/// <param name="FullyQualifiedName">An optional fully qualified name (<c>null</c> for parameter or field types).</param>
public record DocType(string Name, DocType[] TypeParams, string? FullyQualifiedName = null)
{
    /// <summary>
    ///     The full name of the type including its type parameters.
    /// </summary>
    public string FullName =>
        $"{Name}{TypeParams.Select(t => t.FullName).Separated(with: ", ").Surround("<", ">")}";
}