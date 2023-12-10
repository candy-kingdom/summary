# [Summary.Markdown.MarkdownPipelineExtensions](../src/Plugins/Markdown/MarkdownPipelineExtensions.cs#L10)
```cs
public static class MarkdownPipelineExtensions
```

A set of extension methods that extend different pipelines with Markdown rendering.

## Methods
### [UseMdRenderer(SummaryPipeline, string, bool)](../src/Plugins/Markdown/MarkdownPipelineExtensions.cs#L18)
```cs
public static SummaryPipeline UseMdRenderer(this SummaryPipeline self, string output, bool cleanup = true)
```

Adds a Markdown renderer to the specified pipeline.

_The renderer will write all the rendered Markdown files to the specified output directory._

