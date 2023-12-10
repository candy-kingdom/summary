# [Summary.Pipelines.SummaryPipeline.Options](../src/Core/Pipelines/SummaryPipeline.cs#L21)
```cs
public class Options
```

A set of options that configure the behavior of the summary pipeline.

## Properties
### LoggerFactory
```cs
public ILoggerFactory LoggerFactory { get; }
```

The factory that provides logger implementations.

## Methods
### UseLoggerFactory(ILoggerFactory)
```cs
public Options UseLoggerFactory(ILoggerFactory loggers)
```

Specifies the logger factory that will be used to create loggers for the pipeline.

