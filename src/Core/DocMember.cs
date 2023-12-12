using System.Diagnostics.CodeAnalysis;

namespace Summary;

/// <summary>
///     A member of the generated document (e.g. type, field, property, method, etc.).
/// </summary>
public abstract record DocMember
{
    /// <summary>
    ///     The namespace the member is defined in.
    /// </summary>
    public required string Namespace { get; init; }

    /// <summary>
    ///     The fully qualified name of the member (e.g., <c>Summary.DocMember</c>).
    /// </summary>
    public required string FullyQualifiedName { get; init; }

    /// <summary>
    ///     The name of the member (e.g. <c>public int Field</c> has name <c>Field</c>).
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    ///     The code-snippet that contains the full declaration of the member
    ///     (e.g. <c>public int Field</c> is a declaration of the field member <c>Field</c>).
    /// </summary>
    public required string Declaration { get; init; }

    /// <summary>
    ///     The access modifier of the member.
    /// </summary>
    public required AccessModifier Access { get; init; }

    /// <summary>
    ///     The documentation comment of the member (can be empty).
    /// </summary>
    public required DocComment Comment { get; init; }

    /// <summary>
    ///     The type that this member is declared in (works for nested types as well).
    /// </summary>
    public required DocType? DeclaringType { get; init; }

    /// <summary>
    ///     Whether the member is deprecated (e.g. marked with <c>[Obsolete]</c>).
    /// </summary>
    [MemberNotNullWhen(true, nameof(Deprecation))]
    public bool Deprecated => Deprecation is not null;

    /// <summary>
    ///     The member deprecation information.
    /// </summary>
    public DocDeprecation? Deprecation { get; init; }

    /// <summary>
    ///     The location of the member.
    /// </summary>
    public DocLocation? Location { get; init; }

    /// <summary>
    ///     The list of <c>using</c> statements imported in the scope of this type declaration.
    /// </summary>
    public required string[] Usings { get; init; }
}