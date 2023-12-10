namespace Summary;

/// <summary>
///     One of the <see cref="DocProperty"/> accessors (e.g., <c>get</c>, <c>set</c>, <c>init</c>).
/// </summary>
public record DocPropertyAccessor
{
    /// <summary>
    ///     The sequence that consists only of a default <c>public get</c> property accessor.
    /// </summary>
    public static DocPropertyAccessor[] Defaults() => new[]
    {
        Default(),
    };

    /// <summary>
    ///     The default <c>public get</c> property accessor.
    /// </summary>
    public static DocPropertyAccessor Default() => new DocPropertyAccessor
    {
        Kind = AccessorKind.Get,
        Access = AccessModifier.Public,
    };

    /// <summary>
    ///     The access modifier of the accessor.
    /// </summary>
    public AccessModifier Access;

    /// <summary>
    ///     The kind of the accessor.
    /// </summary>
    public AccessorKind Kind;
}