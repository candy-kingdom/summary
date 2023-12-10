namespace Summary.Pipes;

/// <summary>
///     A <see cref="IPipe{I,O}"/> that composes two pipes together.
/// </summary>
public class ThenPipe<I, O1, O2>(IPipe<I, O1> a, IPipe<O1, O2> b) : IPipe<I, O2>
{
    /// <inheritdoc />
    public async Task<O2> Run(I i)
    {
        var x = await a.Run(i).ConfigureAwait(false);
        var y = await b.Run(x).ConfigureAwait(false);

        return y;
    }
}