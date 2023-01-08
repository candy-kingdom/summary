namespace Summary.Pipes;

/// <summary>
///     A <see cref="IPipe{I,O}"/> that composes two pipes together.
/// </summary>
public class ThenPipe<I, O1, O2> : IPipe<I, O2>
{
    private readonly IPipe<I, O1> _a;
    private readonly IPipe<O1, O2> _b;

    public ThenPipe(IPipe<I, O1> a, IPipe<O1, O2> b)
    {
        _a = a;
        _b = b;
    }

    public async Task<O2> Run(I i)
    {
        var a = await _a.Run(i).ConfigureAwait(false);
        var b = await _b.Run(a).ConfigureAwait(false);

        return b;
    }
}