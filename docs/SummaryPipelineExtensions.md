# [Summary.Pipelines.SummaryPipelineExtensions](../src/Core/Pipelines/SummaryPipelineExtensions.cs#L9)
```cs
public static class SummaryPipelineExtensions
```

Convenient extensions for [`SummaryPipeline`](./SummaryPipeline.md).

## Methods
### [UseLoggerFactory(SummaryPipeline, ILoggerFactory)](../src/Core/Pipelines/SummaryPipelineExtensions.cs#L18)
```cs
public static SummaryPipeline UseLoggerFactory(this SummaryPipeline self, ILoggerFactory factory)
```

Specifies the logger factory to use for pipes inside the pipeline.

_This method should be called _before_ anything else so that_
_given logger factory is passed into all subsequent calls._

### [UseDefaultFilters(SummaryPipeline)](../src/Core/Pipelines/SummaryPipelineExtensions.cs#L24)
```cs
public static SummaryPipeline UseDefaultFilters(this SummaryPipeline self)
```

Enables default filters for the given pipeline (i.e. a filter that removes all non-public members).

### [IncludeAtLeast(SummaryPipeline, AccessModifier)](../src/Core/Pipelines/SummaryPipelineExtensions.cs#L39)
```cs
public static SummaryPipeline IncludeAtLeast(this SummaryPipeline self, AccessModifier access)
```

Includes only members that have at least the given access modifier.

#### Example
In order to include both `internal` and `public` members in the generated docs,
you can call this method as follows:
```cs
var pipeline = ...;

pipeline.IncludeAtLeast(AccessModifier.Internal);
```

### [IncludeOnly(SummaryPipeline, AccessModifier)](../src/Core/Pipelines/SummaryPipelineExtensions.cs#L54)
```cs
public static SummaryPipeline IncludeOnly(this SummaryPipeline self, AccessModifier access)
```

Includes only members that have at least the given access modifier.

#### Example
In order to include onl `internal` members in the generated docs,
you can call this method as follows:
```cs
var pipeline = ...;

pipeline.IncludeOnly(AccessModifier.Internal);
```

### [UseFilter(SummaryPipeline, IPipe<Doc, Doc>)](../src/Core/Pipelines/SummaryPipelineExtensions.cs#L61)
```cs
public static SummaryPipeline UseFilter(this SummaryPipeline self, IPipe<Doc, Doc> filter)
```

Adds the given filter into the pipeline.
