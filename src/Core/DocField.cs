namespace Summary;

/// <summary>
///     A <see cref="DocMember" /> that represents a documented field in the parsed source code.
/// </summary>
public record DocField : DocMember
{
    /// <summary>
    ///     The type of the field.
    /// </summary>
    public required DocType Type { get; init; }
}