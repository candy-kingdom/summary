# [Summary.Pipelines.FilteringExtensions](../src/Core/Pipelines/SummaryPipelineFilteringExtensions.cs#L9)
```cs
public static class FilteringExtensions
```

A set of extensions for [`SummaryPipeline`](./Summary.Pipelines.SummaryPipeline.md) that add support for filtering functionality.

## Methods
### [UseDefaultFilters(SummaryPipeline)](../src/Core/Pipelines/SummaryPipelineFilteringExtensions.cs#L14)
```cs
public static SummaryPipeline UseDefaultFilters(this SummaryPipeline self)
```

Enables default filters for the given pipeline (i.e. a filter that removes all non-public members).

### [IncludeAtLeast(SummaryPipeline, AccessModifier)](../src/Core/Pipelines/SummaryPipelineFilteringExtensions.cs#L29)
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

### [IncludeOnly(SummaryPipeline, AccessModifier)](../src/Core/Pipelines/SummaryPipelineFilteringExtensions.cs#L44)
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

### [WithAccess(SummaryPipeline, Func&lt;AccessModifier, bool&gt;)](../src/Core/Pipelines/SummaryPipelineFilteringExtensions.cs#L50)
```cs
public static SummaryPipeline WithAccess(this SummaryPipeline self, Func<AccessModifier, bool> p)
```

Includes only members that have the access modifier that satisfies the given predicate.

### [UseFilter(SummaryPipeline, IPipe&lt;Doc, Doc&gt;)](../src/Core/Pipelines/SummaryPipelineFilteringExtensions.cs#L67)
```cs
public static SummaryPipeline UseFilter(this SummaryPipeline self, IPipe<Doc, Doc> filter)
```

Adds the given filter into the pipeline.

