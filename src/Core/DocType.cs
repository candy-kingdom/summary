namespace Summary;

/// <summary>
///     A <see cref="DocMember"/> that represents a documented type in the parsed source code.
/// </summary>
/// <inheritdoc cref="DocMember"/>
public record DocType(
    string Name,
    string Declaration,
    AccessModifier Access,
    DocComment Comment,
    DocMember[] Members,
    DocTypeParam[] TypeParams) : DocMember(Name, Declaration, Access, Comment);