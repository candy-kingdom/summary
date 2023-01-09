namespace Summary.Pipes;

/// <summary>
///     A <see cref="IPipe{I,O}"/> that aggregates the result of the specified pipe.
/// </summary>
public class ThenForEach<I, O1, O2> : IPipe<I, O2[]>
{
    private readonly IPipe<I, O1[]> _inner;
    private readonly IPipe<O1, O2> _map;

    public ThenForEach(IPipe<I, O1[]> inner, IPipe<O1, O2> map)
    {
        _inner = inner;
        _map = map;
    }

    public async Task<O2[]> Run(I input)
    {
        var os = await _inner.Run(input).ConfigureAwait(false);

        return await Task.WhenAll(os.Select(_map.Run).ToArray()).ConfigureAwait(false);
    }
}