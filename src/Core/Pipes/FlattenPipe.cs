namespace Summary.Pipes;

/// <summary>
///     A <see cref="IPipe{I,O}"/> that aggregates the result of the specified pipe.
/// </summary>
public class FlattenPipe<I, O> : IPipe<I, O>
{
    private readonly IPipe<I, O[]> _inner;
    private readonly Func<O, O, O> _merge;

    public FlattenPipe(IPipe<I, O[]> inner, Func<O, O, O> merge)
    {
        _inner = inner;
        _merge = merge;
    }

    public async Task<O> Run(I input)
    {
        var os = await _inner.Run(input).ConfigureAwait(false);

        return os.Aggregate(_merge);
    }
}