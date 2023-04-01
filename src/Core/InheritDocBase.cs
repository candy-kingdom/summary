namespace Summary;

/// <summary>
///     Summary.
/// </summary>
/// <remarks>
///     Remarks section.
/// </remarks>
public class InheritDocBase
{
}

/// <inheritdoc />
public class InheritDocSample_Child : InheritDocBase
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