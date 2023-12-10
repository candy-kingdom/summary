# [Summary.Pipelines.SummaryPipeline.Options](../src/Core/Pipelines/SummaryPipeline.cs#L21)
```cs
public class Options
```

A set of options that configure the behavior of the summary pipeline.

## Properties
### [LoggerFactory](../src/Core/Pipelines/SummaryPipeline.cs#L28)
```cs
public ILoggerFactory LoggerFactory { get; }
```

The factory that provides logger implementations.

## Methods
### [UseLoggerFactory(ILoggerFactory)](../src/Core/Pipelines/SummaryPipeline.cs#L33)
```cs
public Options UseLoggerFactory(ILoggerFactory loggers)
```

Specifies the logger factory that will be used to create loggers for the pipeline.

