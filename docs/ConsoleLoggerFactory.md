# [Summary.Cli.Logging.ConsoleLoggerFactory](../src/Cli/Logging/ConsoleLoggerFactory.cs#L8)
```cs
public class ConsoleLoggerFactory : ILoggerFactory
```

A simple factory for console loggers that format messages in the Summary CLI way.

## Fields
### [Instance](../src/Cli/Logging/ConsoleLoggerFactory.cs#L36)
```cs
public static readonly ILogger Instance
```

## Methods
### [Dispose()](../src/Cli/Logging/ConsoleLoggerFactory.cs#L26)
```cs
public void Dispose()
```

### [Log<TState>(LogLevel, EventId, TState, Exception?<Exception>, Func<TState, Exception?<Exception>, string>)](../src/Cli/Logging/ConsoleLoggerFactory.cs#L40)
```cs
public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception? exception,
            Func<TState, Exception?, string> formatter)
```

### [IsEnabled(LogLevel)](../src/Cli/Logging/ConsoleLoggerFactory.cs#L48)
```cs
public bool IsEnabled(LogLevel logLevel)
```

### [BeginScope<TState>(TState)](../src/Cli/Logging/ConsoleLoggerFactory.cs#L50)
```cs
public IDisposable? BeginScope<TState>(TState state)
```

### [CreateLogger(string)](../src/Cli/Logging/ConsoleLoggerFactory.cs#L62)
```cs
public ILogger CreateLogger(string categoryName)
```

### [AddProvider(ILoggerProvider)](../src/Cli/Logging/ConsoleLoggerFactory.cs#L64)
```cs
public void AddProvider(ILoggerProvider provider)
```

### [Dispose()](../src/Cli/Logging/ConsoleLoggerFactory.cs#L68)
```cs
public void Dispose()
```

