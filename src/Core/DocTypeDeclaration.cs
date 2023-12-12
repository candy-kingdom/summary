using Summary.Caching;
using Summary.Extensions;

namespace Summary;

/// <summary>
///     A <see cref="DocMember" /> that represents a documented type declaration
///     (e.g. <c>struct</c>, <c>class</c>, etc.) in the parsed source code.
/// </summary>
public record DocTypeDeclaration : DocMember
{
    /// <summary>
    ///     The members of this type (e.g. fields, properties, methods).
    /// </summary>
    public required DocMember[] Members { get; init; }

    /// <summary>
    ///     The type parameters of this type (if it's generic).
    /// </summary>
    public required DocTypeParam[] TypeParams { get; init; }

    /// <summary>
    ///     The list of base types for this one.
    /// </summary>
    public required DocType[] Base { get; init; }

    /// <summary>
    ///     Whether this type declaration is a record declaration.
    /// </summary>
    public required bool Record { get; init; }

    /// <summary>
    ///     All nested members (including children of children) of this type declaration.
    /// </summary>
    public IEnumerable<DocMember> AllMembers =>
        Members.Dfs(x => x is DocTypeDeclaration type ? type.Members : Enumerable.Empty<DocMember>());

    /// <summary>
    ///     A sequence of members of this type declaration that has the same type as the specified one.
    /// </summary>
    public IEnumerable<DocMember> MembersOfType(DocMember member) =>
        Members.Where(x => x.GetType() == member.GetType());

    /// <summary>
    ///     This type declaration and the sequence of type declarations that are base types of this one.
    /// </summary>
    /// <remarks>
    ///     This method is recursive and will return the sequence of all base types, even non-direct ones.
    /// </remarks>
    public IEnumerable<DocTypeDeclaration> SelfAndBaseDeclarations(Doc doc) =>
        new[] { this }.Concat(BaseDeclarations(doc));

    /// <summary>
    ///     A sequence of type declarations that are base types of this one.
    /// </summary>
    /// <inheritdoc cref="SelfAndBaseDeclarations" />
    public IEnumerable<DocTypeDeclaration> BaseDeclarations(Doc doc) =>
        Base.Select(doc.Declaration).NonNulls().SelectMany(x => x.SelfAndBaseDeclarations(doc));
}