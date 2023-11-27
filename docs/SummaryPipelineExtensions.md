# Summary.Pipelines.SummaryPipelineExtensions
```cs
public static class SummaryPipelineExtensions
```

Convenient extensions for [`SummaryPipeline`](./SummaryPipeline.md).

## Methods
### UseLoggerFactory(SummaryPipeline, ILoggerFactory)
```cs
public static SummaryPipeline UseLoggerFactory(this SummaryPipeline self, ILoggerFactory factory)
```

Specifies the logger factory to use for pipes inside the pipeline.

_This method should be called _before_ anything else so that_
_given logger factory is passed into all subsequent calls._

### IncludeNonPublicMembers(SummaryPipeline)
```cs
public static SummaryPipeline IncludeNonPublicMembers(this SummaryPipeline self)
```

Disables [`FilterPublicMembersPipe`](./FilterPublicMembersPipe.md) filter in the pipeline.
This makes the generator to include private members into the parsed document.

### UseFilter(SummaryPipeline, IPipe<Doc, Doc>)
```cs
public static SummaryPipeline UseFilter(this SummaryPipeline self, IPipe<Doc, Doc> filter)
```

Adds the given filter into the pipeline.

