namespace Summary;

/// <summary>
///     A <see cref="DocProperty" /> that represents an indexer.
/// </summary>
public record DocIndexer : DocProperty
{
    /// <summary>
    ///     The parameters of the indexer.
    /// </summary>
    public required DocParam[] Params { get; init; }
}