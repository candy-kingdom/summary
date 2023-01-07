namespace Doc.Net.Core.Pipes;

/// <summary>
///     Extension methods for <see cref="IPipe{I,O}"/>.
/// </summary>
public static class PipeExtensions
{
    /// <summary>
    ///     Asynchronously runs the pipe.
    /// </summary>
    public static Task<O> Run<O>(this IPipe<Unit, O> pipe) =>
        pipe.Run(Unit.Value);

    /// <summary>
    ///     Asynchronously runs the pipe.
    /// </summary>
    public static Task<Unit> Run(this IPipe<Unit, Unit> pipe) =>
        pipe.Run(Unit.Value);

    /// <summary>
    ///     Composes the pipe with another pipe so that the output of the first pipe is passed as an input to the second pipe.
    /// </summary>
    public static IPipe<I, O2> Then<I, O1, O2>(this IPipe<I, O1> a, IPipe<O1, O2> b) =>
        new ThenPipe<I, O1, O2>(a, b);

    /// <summary>
    ///     Constructs a new pipe that will execute the specified `tee` action on the output.
    /// </summary>
    public static IPipe<I, O> Tee<I, O>(this IPipe<I, O> a, Action<O> tee) =>
        new TeePipe<I, O>(a, tee);

    /// <summary>
    ///     Constructs a new pipe that will apply the specified `select` function to the output of the current pipe.
    /// </summary>
    public static IPipe<I, O2> Select<I, O1, O2>(this IPipe<I, O1> a, Func<O1, O2> select) =>
        a.Then(new FuncPipe<O1, O2>(select));
}