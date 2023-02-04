namespace Summary;

/// <summary>
///     A <see cref="DocMember"/> that represents a documented method in the parsed source code.
/// </summary>
/// <inheritdoc cref="DocMember"/>
public record DocMethod(
    string Name,
    string Declaration,
    AccessModifier Access,
    DocComment Comment,
    DocParam[] Params,
    DocTypeParam[] TypeParams) : DocMember(Name, Declaration, Access, Comment);