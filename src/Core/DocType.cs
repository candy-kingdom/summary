using Summary.Extensions;

namespace Summary;

/// <summary>
///     A simple type (e.g. `int`, `string`, `List&lt;int&gt;`, etc.).
/// </summary>
/// <param name="Name">The name of the type (without generic arguments).</param>
/// <param name="TypeParams">The generic parameters of this type (if it's generic).</param>
public record DocType(string Name, DocType[] TypeParams)
{
    /// <summary>
    ///     The full name of the type including its type parameters.
    /// </summary>
    public string FullName =>
        $"{Name}{TypeParams.Select(t => t.FullName).Separated(with: ", ").Surround("<", ">")}";
}