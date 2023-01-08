namespace Summary.Pipes;

/// <summary>
///     A <see cref="IPipe{I,O}"/> that wraps <see cref="Func{I,O}"/>.
/// </summary>
public class FuncPipe<I, O> : IPipe<I, O>
{
    private readonly Func<I, Task<O>> _func;

    public FuncPipe(Func<I, O> func) =>
        _func = i => Task.FromResult(func(i));

    public FuncPipe(Func<I, Task<O>> func) =>
        _func = func;

    public Task<O> Run(I input) =>
        _func(input);
}