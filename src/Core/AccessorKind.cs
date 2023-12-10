namespace Summary;

/// <summary>
///     The kind of <see cref="DocProperty"/> accessor.
/// </summary>
/// <remarks>
///     We intentionally omit event accessors like <c>add</c> or <c>remove</c> since
///     each event has both, and the modifiers are not supported by event accessors.
/// </remarks>
public enum AccessorKind
{
    /// <summary>
    ///     It's a <c>get</c> accessor.
    /// </summary>
    Get,

    /// <summary>
    ///     It's a <c>set</c> accessor.
    /// </summary>
    Set,

    /// <summary>
    ///     It's a <c>init</c> accessor.
    /// </summary>
    Init,
}

