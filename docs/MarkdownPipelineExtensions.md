# Summary.Markdown.MarkdownPipelineExtensions
A set of extension methods that extend different pipelines with Markdown rendering.

```cs
public static class MarkdownPipelineExtensions
```

## Methods
### UseMdRenderer(SummaryPipeline, string)
Adds a Markdown renderer to the specified pipeline.

_The renderer will write all the rendered Markdown files to the specified output directory._

```cs
public static SummaryPipeline UseMdRenderer(this SummaryPipeline self, string output)
```

