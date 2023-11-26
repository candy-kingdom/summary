using Summary.Pipes;

namespace Summary.Tests;

/// <summary>
///     Extension methods that simplify unit testing and should not be included in the package.
/// </summary>
public static class Extensions
{
    /// <summary>
    ///     Runs the pipe synchronously.
    /// </summary>
    /// <param name="self">The pipe to execute.</param>
    public static O RunSync<O>(this IPipe<Unit, O> self) =>
        self.Run().Result;

    /// <inheritdoc cref="RunSync{O}(Summary.Pipes.IPipe{Unit,O})"/>
    public static O RunSync<I, O>(this IPipe<I, O> self, I input) =>
        self.Run(input).Result;
}