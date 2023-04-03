namespace Summary;

/// <summary>
///     A <see cref="DocMember" /> that represents a documented property in the parsed source code.
/// </summary>
/// <param name="Type">The type of the property.</param>
/// <inheritdoc cref="DocMember" />
public record DocProperty(
        DocType Type,
        string FullyQualifiedName,
        string Name,
        string Declaration,
        AccessModifier Access,
        DocComment Comment,
        DocType? DeclaringType,
        bool Generated = false,
        bool Event = false)
    : DocMember(FullyQualifiedName, Name, Declaration, Access, Comment, DeclaringType);