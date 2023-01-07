namespace Doc.Net.Core.Pipes;

/// <summary>
///     A void type that is similar to `void` keyword.
/// </summary>
public class Unit
{
    /// <summary>
    ///     The only instance of the <see cref="Unit"/>.
    /// </summary>
    public static readonly Unit Value = new();

    /// <summary>
    ///     The completed task instance that contains the <see cref="Unit"/> value.
    /// </summary>
    public static readonly Task<Unit> CompletedTask = Task.FromResult(Value);

    // Disallow creating instances of this class.
    private Unit() { }
}