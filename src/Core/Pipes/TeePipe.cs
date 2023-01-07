namespace Doc.Net.Core.Pipes;

/// <summary>
///     A <see cref="IPipe{I,O}"/> that invokes an action on the output of the pipe each time it's executed.
/// </summary>
public class TeePipe<I, O> : IPipe<I, O>
{
    private readonly IPipe<I, O> _inner;
    private readonly Action<O> _tee;

    public TeePipe(IPipe<I, O> inner, Action<O> tee)
    {
        _inner = inner;
        _tee = tee;
    }

    public async Task<O> Run(I input)
    {
        var output =  await _inner.Run(input).ConfigureAwait(false);

        _tee(output);

        return output;
    }
}