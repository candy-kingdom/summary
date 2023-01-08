namespace Summary.Pipes;

/// <summary>
///     A <see cref="IPipe{I,O}"/> that aggregates the result of the specified pipe.
/// </summary>
public class FlattenPipe<O> : IPipe<O[], O>
{
    private readonly Func<O, O, O> _merge;

    public FlattenPipe(Func<O, O, O> merge) =>
        _merge = merge;

    public Task<O> Run(O[] input) =>
        Task.FromResult(input.Aggregate(_merge));
}