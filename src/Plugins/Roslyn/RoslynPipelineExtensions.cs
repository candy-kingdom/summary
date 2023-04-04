using Summary.Pipelines;
using Summary.Pipes;
using Summary.Pipes.Filters;
using Summary.Pipes.IO;
using Summary.Roslyn.CSharp;

namespace Summary.Roslyn;

/// <summary>
///     A set of extension methods that extend different pipelines with Roslyn parsing.
/// </summary>
public static class RoslynPipelineExtensions
{
    /// <summary>
    ///     Adds a Roslyn parser to the specified pipeline.
    /// </summary>
    /// <remarks>
    ///     This parser will parse all the C# files in the specified directory
    ///     and will extract comments from the corresponding syntax trees using Roslyn API.
    ///     <br />
    ///     This method is both fast and reliable, and allows better customization.
    /// </remarks>
    public static SummaryPipeline UseRoslynParser(this SummaryPipeline self, string root, string pattern = "*.cs") =>
        self.ParseWith(
            new ScanDirectoryPipe(root, pattern)
                .ThenForEach(new ParseSyntaxTreePipe())
                .ThenForEach(new ParseDocPipe())
                .Then(new FoldPipe<Doc>(Doc.Merge))
                .Then(new InlineInheritDocPipe())
                .Then(new FilterPublicMembersPipe()));
}