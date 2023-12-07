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

### UseDefaultFilters(SummaryPipeline)
```cs
public static SummaryPipeline UseDefaultFilters(this SummaryPipeline self)
```

Enables default filters for the given pipeline (i.e. a filter that removes all non-public members).

### IncludeAtLeast(SummaryPipeline, AccessModifier)
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

### IncludeOnly(SummaryPipeline, AccessModifier)
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

### UseFilter(SummaryPipeline, IPipe<Doc, Doc>)
```cs
public static SummaryPipeline UseFilter(this SummaryPipeline self, IPipe<Doc, Doc> filter)
```

Adds the given filter into the pipeline.

