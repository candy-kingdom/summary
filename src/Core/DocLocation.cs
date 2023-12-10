namespace Summary;

/// <summary>
///     The location of the documented member.
/// </summary>
public record DocLocation
{
    /// <summary>
    ///     The path to the file where the member is located.
    /// </summary>
    public required string Path { get; init; }

    /// <summary>
    ///     The location where the member starts.
    /// </summary>
    public required (int Line, int? Column) Start { get; init; }

    /// <summary>
    ///     The location where the member ends.
    /// </summary>
    public (int Line, int? Column)? End { get; init; }
}