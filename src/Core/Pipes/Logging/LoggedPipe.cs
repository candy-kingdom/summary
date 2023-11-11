using Microsoft.Extensions.Logging;

namespace Summary.Pipes.Logging;

/// <summary>
///     A <see cref="IPipe{I,O}"/> whose output is logged using the provided logger.
/// </summary>
public class LoggedPipe<I, O> : IPipe<I, O>
{
    private readonly IPipe<I, O> _inner;
    private readonly ILogger _logger;
    private readonly string _message;

    public LoggedPipe(IPipe<I, O> inner, ILogger logger, string message)
    {
        _inner = inner;
        _logger = logger;
        _message = message;
    }

    public Task<O> Run(I input)
    {
        using var _ = _logger.BeginScope(_message);

        return _inner.Run(input);
    }
}