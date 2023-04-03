﻿using Summary.Extensions;

namespace Summary;

/// <summary>
///     A <see cref="DocMember"/> that represents a documented type declaration (e.g. `struct`, `class`, etc.)
///     in the parsed source code.
/// </summary>
/// <param name="Members">The members of this type (e.g. fields, properties, methods).</param>
/// <param name="TypeParams">The type parameters of this type (if it's generic).</param>
/// <param name="Parent">The containing type this type is defined in (`null` if none).</param>
/// <param name="Base">The list of base types for this one.</param>
/// <inheritdoc cref="DocMember"/>
public record DocTypeDeclaration(
    string FullyQualifiedName,
    string Name,
    string Declaration,
    AccessModifier Access,
    DocComment Comment,
    DocMember[] Members,
    DocTypeParam[] TypeParams,
    DocTypeDeclaration? Parent,
    DocType[] Base,
    bool Record = false) : DocMember(Name, Declaration, Access, Comment)

{
    /// <summary>
    ///     This type declaration and the sequence of type declarations that are base types of this one.
    /// </summary>
    /// <remarks>
    ///     This method is recursive and will return the sequence of all base types, even non-direct ones.
    /// </remarks>
    public IEnumerable<DocTypeDeclaration> BaseDeclarationsAndSelf(Doc doc) =>
        new[] { this }.Concat(BaseDeclarations(doc));

    /// <summary>
    ///     A sequence of type declarations that are base types of this one.
    /// </summary>
    /// <inheritdoc cref="BaseDeclarationsAndSelf" />
    public IEnumerable<DocTypeDeclaration> BaseDeclarations(Doc doc) =>
        Base.Select(doc.Declaration).NonNulls().SelectMany(x => x.BaseDeclarationsAndSelf(doc));
}