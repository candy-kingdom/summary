namespace Summary.Pipes;

/// <summary>
///     A void type that is similar to `void` keyword.
/// </summary>
public class Unit
{
    /// <summary>
    ///     The only instance of the <see cref="Unit"/>.
    /// </summary>
    public static readonly Unit Value = new();

    // Disallow creating instances of this class.
    private Unit()
    {
    }
}