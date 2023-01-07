namespace Doc.Net.Core;

/// <summary>
///     A <see cref="DocMember"/> that represents a documented type in the parsed source code.
/// </summary>
/// <inheritdoc cref="DocMember"/>
public record DocType(string Name, string Declaration, AccessModifier Access, DocComment Comment, DocMember[] Members)
    : DocMember(Name, Declaration, Access, Comment);