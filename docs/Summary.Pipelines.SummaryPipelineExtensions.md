# [Summary.Pipelines.SummaryPipelineExtensions](../src/Core/Pipelines/SummaryPipelineExtensions.cs#L10)
```cs
public static class SummaryPipelineExtensions
```

Convenient extensions for [`SummaryPipeline`](./Summary.Pipelines.SummaryPipeline.md).

## Methods
### [UseLoggerFactory(SummaryPipeline, ILoggerFactory)](../src/Core/Pipelines/SummaryPipelineExtensions.cs#L19)
```cs
public static SummaryPipeline UseLoggerFactory(this SummaryPipeline self, ILoggerFactory factory)
```

Specifies the logger factory to use for pipes inside the pipeline.

_This method should be called _before_ anything else so that_
_given logger factory is passed into all subsequent calls._

