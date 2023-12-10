namespace Summary;

/// <summary>
///     A <see cref="DocMember" /> that represents a documented event in the parsed source code.
/// </summary>
/// <remarks>
///     Similar to <see cref="DocProperty"/> but with its own set of accessors.
/// </remarks>
public record DocEvent : DocMember
{
    /// <summary>
    ///     The type of the event.
    /// </summary>
    public required DocType Type { get; init; }
}