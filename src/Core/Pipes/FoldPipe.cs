namespace Summary.Pipes;

/// <summary>
///     A <see cref="IPipe{I,O}"/> that aggregates the result of the specified pipe.
/// </summary>
public class FoldPipe<O> : IPipe<O[], O>
{
    private readonly Func<O, O, O> _fold;

    public FoldPipe(Func<O, O, O> fold) =>
        _fold = fold;

    public Task<O> Run(O[] input) =>
        Task.FromResult(input.Aggregate(_fold));
}