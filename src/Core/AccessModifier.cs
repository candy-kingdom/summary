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
    ///     The <c>private</c> keyword access modifier.
    /// </summary>
    Private,

    /// <summary>
    ///     The <c>protected</c> keyword access modifier.
    /// </summary>
    Protected,

    /// <summary>
    ///     The <c>internal</c> keyword access modifier.
    /// </summary>
    Internal,

    /// <summary>
    ///     The <c>public</c> keyword access modifier.
    /// </summary>
    Public,
}