using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Summary.Cli.Logging;

/// <summary>
///     A simple factory for console loggers that format messages in the Summary CLI way.
/// </summary>
public class ConsoleLoggerFactory : ILoggerFactory
{
    private class Logger : ILogger
    {
        private class Scope : IDisposable
        {
            private const int Indent = 2;

            private readonly Logger _logger;
            private readonly Stopwatch _sw;

            public Scope(Logger logger)
            {
                _logger = logger;
                _logger._indent += Indent;
                _sw = Stopwatch.StartNew();
            }

            public void Dispose()
            {
                _logger._indent -= Indent;
                _logger.Log($"{Done} Done! ({_sw.ElapsedMilliseconds} ms.)");
            }
        }

        private const string Arrow = ">";
        private const string Done = "✓";

        public static readonly ILogger Instance = new Logger();

        private int _indent;

        public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception? exception,
            Func<TState, Exception?, string> formatter) =>
            Log(state);

        public bool IsEnabled(LogLevel logLevel) => true;

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            Log($"{Arrow} {state}");

            return new Scope(this);
        }

        private void Log<S>(S state) => Console.WriteLine($"{Indent()}{state}");

        private string Indent() => new(' ', _indent);
    }

    public ILogger CreateLogger(string categoryName) => Logger.Instance;

    public void AddProvider(ILoggerProvider provider)
    {
    }

    public void Dispose()
    {
    }
}