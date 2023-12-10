using Microsoft.Extensions.Logging;

namespace Summary.Pipes.Logging;

/// <summary>
///     A <see cref="IPipe{I,O}"/> whose output is logged using the provided logger.
/// </summary>
/// <remarks>
///     Logging is implemented by simply beginning a new scope with the given message.
/// </remarks>
public class LoggedPipe<I, O>(IPipe<I, O> inner, ILogger logger, Func<I, string> message) : IPipe<I, O>
{
    /// <summary>
    ///     Initializes a pipe.
    /// </summary>
    public LoggedPipe(IPipe<I, O> inner, ILogger logger, string message)
        : this(inner, logger, _ => message) { }

    /// <inheritdoc />
    public Task<O> Run(I input)
    {
        using var _ = logger.BeginScope(message(input));

        return inner.Run(input);
    }
}