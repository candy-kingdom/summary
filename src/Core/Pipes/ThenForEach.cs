namespace Summary.Pipes;

/// <summary>
///     A <see cref="IPipe{I,O}"/> that aggregates the result of the specified pipe.
/// </summary>
public class ThenForEach<I, O1, O2>(IPipe<I, O1[]> inner, IPipe<O1, O2> map) : IPipe<I, O2[]>
{
    public async Task<O2[]> Run(I input)
    {
        var os = await inner.Run(input).ConfigureAwait(false);

        return await Task.WhenAll(os.Select(map.Run).ToArray()).ConfigureAwait(false);
    }
}