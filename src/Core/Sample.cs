namespace Summary;

/// <summary>
///     A sample class that is documented.
///
///     This a second paragraph.
///     It is indented.
///
///     This is the third paragraph.
///
///     Here is a <c>code</c> fragment.
/// </summary>
/// <remarks>
///     Remarks section.
///     Second line.
///
///     Another paragraph.
/// </remarks>
public class Sample<T0, T1>
{
    /// <summary>
    ///     A sample field.
    /// </summary>
    public int Field1;

    /// <summary>
    ///     A sample property.
    /// </summary>
    public int Property1 { get; set; }

    /// <summary>
    ///     A simple method.
    ///
    ///     It contains two parameters:
    ///     - <paramref name="x"/> means `x`
    ///     - <paramref name="y"/> means `y`
    /// </summary>
    /// <param name="x">The `x` of the method.</param>
    /// <param name="y">The `y` of the method.</param>
    /// <typeparam name="M0">The first type parameter of the method.</typeparam>
    /// <typeparam name="M1">The second type parameter of the method.</typeparam>
    /// <typeparam name="M2">The third type parameter of the method.</typeparam>
    /// <returns>The `TimeSpan` instance.</returns>
    public TimeSpan Method<M0, M1, M2>(int x, string y) =>
        TimeSpan.Zero;

    /// <summary>
    ///     The overloaded <see cref="Method{M0,M1,M2}(int,string)"/>.
    /// </summary>
    /// <inheritdoc cref="Method{M0,M1,M2}(int,string)"/>
    public TimeSpan Method<M0, M1, M2>(short x, string y) =>
        TimeSpan.Zero;
}