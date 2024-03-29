# [Summary.Roslyn.RoslynPipelineExtensions](../src/Plugins/Roslyn/RoslynPipelineExtensions.cs#L13)
```cs
public static class RoslynPipelineExtensions
```

A set of extension methods that extend different pipelines with Roslyn parsing.

## Methods
### [UseRoslynParser(SummaryPipeline, string, string)](../src/Plugins/Roslyn/RoslynPipelineExtensions.cs#L16)
```cs
public static SummaryPipeline UseRoslynParser(this SummaryPipeline self, string source, string pattern = "*.cs")
```

Adds a Roslyn parser to the specified pipeline.

_This parser will parse all the C# files in the specified directory_
_and will extract comments from the corresponding syntax trees using Roslyn API._
_<para/>_
_Under the hood, we call <u>`System.IO.Directory.EnumerateFiles(string, string, SearchOption)`</u> method_
_to get the list of all files for each of the specified root paths, and then concatenate the results._

### [UseRoslynParser(SummaryPipeline, string[], string)](../src/Plugins/Roslyn/RoslynPipelineExtensions.cs#L29)
```cs
public static SummaryPipeline UseRoslynParser(this SummaryPipeline self, string[] sources, string pattern = "*.cs")
```

Adds a Roslyn parser to the specified pipeline.

_This parser will parse all the C# files in the specified directory_
_and will extract comments from the corresponding syntax trees using Roslyn API._
_<para/>_
_Under the hood, we call <u>`System.IO.Directory.EnumerateFiles(string, string, SearchOption)`</u> method_
_to get the list of all files for each of the specified root paths, and then concatenate the results._

