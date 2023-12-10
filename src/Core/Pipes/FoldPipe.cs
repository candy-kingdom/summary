namespace Summary.Pipes;

/// <summary>
///     A <see cref="IPipe{I,O}" /> that aggregates the result of the specified pipe.
/// </summary>
public class FoldPipe<O>(Func<O, O, O> fold, O @default) : IPipe<O[], O>
{
    /// <inheritdoc />
    public Task<O> Run(O[] input) =>
        Task.FromResult(input.Length is 0 ? @default : input.Aggregate(fold));
}