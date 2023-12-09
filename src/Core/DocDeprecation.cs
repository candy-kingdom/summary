namespace Summary;

/// <summary>
///     Contains deprecation information (e.g. the warning message).
/// </summary>
public record DocDeprecation
{
    /// <summary>
    ///     The deprecation warning message.
    /// </summary>
    public string? Message { get; init; }

    /// <summary>
    ///     Whether the usage should be treated as an error instead of a warning.
    /// </summary>
    public bool Error { get; init; }
}