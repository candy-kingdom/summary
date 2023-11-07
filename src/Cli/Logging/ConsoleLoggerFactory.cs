using Microsoft.Extensions.Logging;

namespace Summary.Cli.Logging;

public class ConsoleLoggerFactory : ILoggerFactory
{
    private class Logger : ILogger
    {
        public static readonly ILogger Instance = new Logger();

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter) =>
            Console.WriteLine(formatter(state, exception));

        public bool IsEnabled(LogLevel logLevel) => true;

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull =>
            throw new NotImplementedException();
    }

    public ILogger CreateLogger(string categoryName) => Logger.Instance;

    public void AddProvider(ILoggerProvider provider)
    {
    }

    public void Dispose()
    {
    }
}