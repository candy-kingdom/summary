namespace Summary;

/// <summary>
///     A <see cref="DocMember" /> that represents a documented field in the parsed source code.
/// </summary>
/// <param name="Type">The type of the field.</param>
/// <inheritdoc cref="DocMember" />
public record DocField(
        DocType Type,
        string FullyQualifiedName,
        string Name,
        string Declaration,
        AccessModifier Access,
        DocComment Comment,
        DocType? DeclaringType)
    : DocMember(FullyQualifiedName, Name, Declaration, Access, Comment, DeclaringType);