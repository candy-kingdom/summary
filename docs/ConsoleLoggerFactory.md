# [Summary.Cli.Logging.ConsoleLoggerFactory](../src/Cli/Logging/ConsoleLoggerFactory.cs#L8)
```cs
public class ConsoleLoggerFactory : ILoggerFactory
```

A simple factory for console loggers that format messages in the Summary CLI way.

## Fields
### Instance
```cs
public static readonly ILogger Instance
```

## Methods
### Dispose()
```cs
public void Dispose()
```

### Log<TState>(LogLevel, EventId, TState, Exception?<Exception>, Func<TState, Exception?<Exception>, string>)
```cs
public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception? exception,
            Func<TState, Exception?, string> formatter)
```

### IsEnabled(LogLevel)
```cs
public bool IsEnabled(LogLevel logLevel)
```

### BeginScope<TState>(TState)
```cs
public IDisposable? BeginScope<TState>(TState state)
```

### CreateLogger(string)
```cs
public ILogger CreateLogger(string categoryName)
```

### AddProvider(ILoggerProvider)
```cs
public void AddProvider(ILoggerProvider provider)
```

### Dispose()
```cs
public void Dispose()
```

