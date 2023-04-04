namespace Summary.Pipes;

/// <summary>
///     A <see cref="IPipe{I,O}" /> that aggregates the result of the specified pipe.
/// </summary>
public class FoldPipe<O> : IPipe<O[], O>
{
    private readonly O _default;
    private readonly Func<O, O, O> _fold;

    public FoldPipe(Func<O, O, O> fold, O @default)
    {
        _fold = fold;
        _default = @default;
    }

    public Task<O> Run(O[] input) =>
        Task.FromResult(input.Length is 0 ? _default : input.Aggregate(_fold));
}