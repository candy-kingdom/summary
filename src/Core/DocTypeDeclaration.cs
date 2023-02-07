namespace Summary;

/// <summary>
///     A <see cref="DocMember"/> that represents a documented type declaration (e.g. `struct`, `class`, etc.)
///     in the parsed source code.
/// </summary>
/// <inheritdoc cref="DocMember"/>
public record DocTypeDeclaration(
    string Name,
    string Declaration,
    AccessModifier Access,
    DocComment Comment,
    DocMember[] Members,
    DocTypeParam[] TypeParams) : DocMember(Name, Declaration, Access, Comment);