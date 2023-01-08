namespace Summary;

/// <summary>
///     An access modifier of a <see cref="DocMember"/> (e.g. `private`, `public`, etc.).
/// </summary>
public enum AccessModifier
{
    /// <summary>
    ///     The `public` keyword access modifier.
    /// </summary>
    Public,

    /// <summary>
    ///     The `protected` keyword access modifier.
    /// </summary>
    Protected,

    /// <summary>
    ///     The `private` keyword access modifier.
    /// </summary>
    Private,

    /// <summary>
    ///     The `internal` keyword access modifier.
    /// </summary>
    Internal,
}