namespace Summary;

/// <summary>
///     The kind of <see cref="DocProperty"/> accessor.
/// </summary>
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

    /// <summary>
    ///     It's an event <c>add</c> accessor.
    /// </summary>
    Add,

    /// <summary>
    ///     It's an event <c>remove</c> accessor.
    /// </summary>
    Remove,
}

