namespace Summary.Pipes;

/// <summary>
///     A <see cref="IPipe{I,O}"/> that invokes an action on the output of the pipe each time it's executed.
/// </summary>
public class TeePipe<I, O>(IPipe<I, O> inner, Action<O> tee) : IPipe<I, O>
{
    /// <inheritdoc />
    public async Task<O> Run(I input)
    {
        var output =  await inner.Run(input).ConfigureAwait(false);

        tee(output);

        return output;
    }
}