namespace Doc.Net.Core;

/// <summary>
///     A <see cref="DocMember"/> that represents a documented property in the parsed source code.
/// </summary>
/// <inheritdoc cref="DocMember"/>
public record DocField(string Name, string Declaration, AccessModifier Access, DocComment Comment)
    : DocMember(Name, Declaration, Access, Comment);