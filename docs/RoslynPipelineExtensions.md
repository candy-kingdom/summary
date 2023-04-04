# RoslynPipelineExtensions
A set of extension methods that extend different pipelines with Roslyn parsing.

```cs
public static class RoslynPipelineExtensions
```

## Methods
### UseRoslynParser(SummaryPipeline, string, string)
Adds a Roslyn parser to the specified pipeline.

_This parser will parse all the C# files in the specified directory_
_and will extract comments from the corresponding syntax trees using Roslyn API._
_<br />_
_This method is both fast and reliable, and allows better customization._

```cs
public static SummaryPipeline UseRoslynParser(this SummaryPipeline self, string root, string pattern = "*.cs")
```

