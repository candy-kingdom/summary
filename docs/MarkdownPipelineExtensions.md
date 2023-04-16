# Summary.Markdown.MarkdownPipelineExtensions
```cs
public static class MarkdownPipelineExtensions
```

A set of extension methods that extend different pipelines with Markdown rendering.

## Methods
### UseMdRenderer(SummaryPipeline, string)
```cs
public static SummaryPipeline UseMdRenderer(this SummaryPipeline self, string output)
```

Adds a Markdown renderer to the specified pipeline.

_The renderer will write all the rendered Markdown files to the specified output directory._

