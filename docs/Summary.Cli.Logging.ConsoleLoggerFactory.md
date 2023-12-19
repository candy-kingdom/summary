# [Summary.Cli.Logging.ConsoleLoggerFactory](../src/Cli/Logging/ConsoleLoggerFactory.cs#L9)
```cs
public class ConsoleLoggerFactory : ILoggerFactory
```

A simple factory for console loggers that format messages in the Summary CLI way.

## Fields
### [Instance](../src/Cli/Logging/ConsoleLoggerFactory.cs#L37)
```cs
public static readonly ILogger Instance
```

## Methods
### [Dispose()](../src/Cli/Logging/ConsoleLoggerFactory.cs#L27)
```cs
public void Dispose()
```

### [Log&lt;TState&gt;(LogLevel, EventId, TState, Exception?&lt;Exception&gt;, Func&lt;TState, Exception?&lt;Exception&gt;, string&gt;)](../src/Cli/Logging/ConsoleLoggerFactory.cs#L41)
```cs
public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception? exception,
            Func<TState, Exception?, string> formatter)
```

### [IsEnabled(LogLevel)](../src/Cli/Logging/ConsoleLoggerFactory.cs#L49)
```cs
public bool IsEnabled(LogLevel logLevel)
```

### [BeginScope&lt;TState&gt;(TState)](../src/Cli/Logging/ConsoleLoggerFactory.cs#L51)
```cs
public IDisposable? BeginScope<TState>(TState state)
```

### [CreateLogger(string)](../src/Cli/Logging/ConsoleLoggerFactory.cs#L63)
```cs
public ILogger CreateLogger(string categoryName)
```

### [AddProvider(ILoggerProvider)](../src/Cli/Logging/ConsoleLoggerFactory.cs#L65)
```cs
public void AddProvider(ILoggerProvider provider)
```

### [Dispose()](../src/Cli/Logging/ConsoleLoggerFactory.cs#L69)
```cs
public void Dispose()
```

