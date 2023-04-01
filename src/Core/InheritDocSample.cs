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
    ///     A field.
    /// </summary>
    public int Field1;

    /// <inheritdoc cref="Field1" />
    public int Field2;

    /// <summary>
    ///     A property.
    /// </summary>
    /// <remarks>
    ///     Property remarks.
    /// </remarks>
    public virtual int Property1 { get; set; }

    /// <inheritdoc cref="Property1" />
    public virtual int Property2 { get; set; }

    /// <inheritdoc cref="Property1" />
    public int Property3 { get; set; }

    /// <summary>
    ///     An event.
    /// </summary>
    public virtual event Action Event1 = () => { };

    /// <summary>
    ///     An indexer.
    /// </summary>
    /// <param name="i">A parameter to the indexer.</param>
    public virtual int this[int i] => 0;

    /// <summary>
    ///     Calculates the sum.
    /// </summary>
    /// <param name="x">The first parameter.</param>
    /// <param name="y">The second parameter.</param>
    /// <returns>Returns the sum of two values.</returns>
    public virtual int Sum(int x, int y) => x + y;
}

/// <inheritdoc />
public class InheritDoc_Child : InheritDocBase
{
    /// <inheritdoc />
    public override int Property1 { get; set; }

    /// <inheritdoc />
    public override event Action Event1 = () => { };

    /// <inheritdoc />
    public override int this[int i] => 0;

    /// <inheritdoc />
    public override int Sum(int x, int y) => x + y;
}

/// <inheritdoc cref="Summary.InheritDocBase" />
public class InheritDoc_Child2 : InheritDoc_Child
{
    /// <inheritdoc />
    public override int Property1 { get; set; }

    /// <inheritdoc />
    public override int Property2 { get; set; }

    /// <inheritdoc cref="InheritDocBase.Property3" />
    public int Property4 { get; set; }

    /// <inheritdoc cref="Summary.InheritDocBase.Property3" />
    public int Property5 { get; set; }

    /// <inheritdoc cref="InheritDocBase.Event1"/>
    public new event Action Event1 = () => { };

    /// <inheritdoc cref="Summary.InheritDocBase.Event1"/>
    public event Action Event2 = () => { };

    /// <inheritdoc cref="Summary.InheritDoc_Child.this" />
    public override int this[int i] => 0;

    /// <inheritdoc />
    /// <remarks>
    ///     Sum remarks.
    /// </remarks>
    public override int Sum(int x, int y) => x + y;
}

/// <summary>
///     Summary.
/// </summary>
/// <remarks>
///     Remarks.
/// </remarks>
public class InheritDoc_CrefBase
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

/// <inheritdoc cref="InheritDoc_CrefBase" />
public class InheritDoc_CrefBase_Child : InheritDoc_CrefBase
{
}

/// <summary>
///     Summary (child).
/// </summary>
/// <inheritdoc />
public class InheritDoc_Child_OverrideSummary : InheritDocBase
{
}

/// <inheritdoc />
/// <summary>
///     Summary (child).
/// </summary>
public class InheritDoc_Child_OverrideSummary2 : InheritDocBase
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
public class InheritDoc_InterfaceChild : IInheritDocBase
{
}

/// <summary>
///    Summary (record).
/// </summary>
/// <param name="Property">A property.</param>
public record InheritDocRecordBase(int Property);

/// <inheritdoc />
/// <param name="OtherProperty">Another property.</param>
public record InheritDocRecordBase_Child(int Property, int OtherProperty) : InheritDocRecordBase(Property);
