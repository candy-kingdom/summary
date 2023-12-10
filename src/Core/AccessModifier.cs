namespace Summary;

/// <summary>
///     An access modifier of a <see cref="DocMember" /> (e.g. <c>private</c>, <c>public</c>, etc.).
/// </summary>
/// <remarks>
///     The modifiers are ordered starting from the smallest one (<see cref="Private" />).
/// </remarks>
public enum AccessModifier
{
    /// <summary>
    ///     The `private` keyword access modifier.
    /// </summary>
    Private,

    /// <summary>
    ///     The `protected` keyword access modifier.
    /// </summary>
    Protected,

    /// <summary>
    ///     The `internal` keyword access modifier.
    /// </summary>
    Internal,

    /// <summary>
    ///     The `public` keyword access modifier.
    /// </summary>
    Public,
}