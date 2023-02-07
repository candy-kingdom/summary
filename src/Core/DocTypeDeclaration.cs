namespace Summary;

/// <summary>
///     A <see cref="DocMember"/> that represents a documented type declaration (e.g. `struct`, `class`, etc.)
///     in the parsed source code.
/// </summary>
/// <param name="Members">The members of this type (e.g. fields, properties, methods).</param>
/// <param name="TypeParams">The type parameters of this type (if it's generic).</param>
/// <param name="Parent">The containing type this type is defined in (`null` if none).</param>
/// <inheritdoc cref="DocMember"/>
public record DocTypeDeclaration(
    string Name,
    string Declaration,
    AccessModifier Access,
    DocComment Comment,
    DocMember[] Members,
    DocTypeParam[] TypeParams,
    DocTypeDeclaration? Parent) : DocMember(Name, Declaration, Access, Comment);