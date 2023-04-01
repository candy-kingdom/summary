namespace Summary;

/// <summary>
///     Summary.
/// </summary>
/// <remarks>
///     Remarks section.
/// </remarks>
public class InheritDocBase
{
    /// <summary>
    ///     Calculates the sum.
    /// </summary>
    /// <param name="x">The first parameter.</param>
    /// <param name="y">The second parameter.</param>
    /// <returns>Returns the sum of two values.</returns>
    public virtual int Sum(int x, int y) => x + y;
}

/// <inheritdoc />
public class InheritDocSample_Child : InheritDocBase
{
    /// <inheritdoc />
    public override int Sum(int x, int y) => x + y;
}

/// <summary>
///     Summary.
/// </summary>
/// <remarks>
///     Remarks.
/// </remarks>
public class InheritDocSample_CrefBase
{
    /// <summary>
    ///     Calculates the sum.
    /// </summary>
    /// <param name="x">The first parameter.</param>
    /// <param name="y">The second parameter.</param>
    /// <returns>Returns the sum of two values.</returns>
    public int Sum(int x, int y) => x + y;

    /// <inheritdoc cref="Sum(int,int)"/>
    public long Sum(long x, long y) => x + y;

    /// <inheritdoc cref="Sum(int,int)"/>
    /// <summary>
    ///     Calculates the sum (override).
    /// </summary>
    public long Sum_OverrideSummary(long x, long y) => x + y;
}

/// <inheritdoc cref="InheritDocSample_CrefBase" />
public class InheritDocSample_CrefBase_Child : InheritDocSample_CrefBase
{
}

/// <summary>
///     Summary (child).
/// </summary>
/// <inheritdoc />
public class InheritDocSample_Child_OverrideSummary : InheritDocBase
{
}

/// <inheritdoc />
/// <summary>
///     Summary (child).
/// </summary>
public class InheritDocSample_Child_OverrideSummary2 : InheritDocBase
{
}

/// <summary>
///     Summary (interface).
/// </summary>
/// <remarks>
///     Remarks section (interface).
/// </remarks>
public interface IInheritDocBase
{
}

/// <inheritdoc />
public class InheritDocSample_InterfaceChild : IInheritDocBase
{
}