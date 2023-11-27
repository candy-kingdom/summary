using Summary.Extensions;
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
    ///     Overall, the method for parsing documentation using Roslyn API, while being dependent on the
    ///     Roslyn packages, is both fast and reliable, and allows better customization.
    ///     We recommend using it by default.
    /// </remarks>
    public static SummaryPipeline UseRoslynParser(this SummaryPipeline self, string root, string pattern = "*.cs") =>
        self.ParseWith(options =>
            new ScanDirectoryPipe(root, pattern)
                .ThenForEach(new ParseSyntaxTreePipe())
                .ThenForEach(new ParseDocPipe())
                .Logged(options.LoggerFactory, $"Parse directory '{root.AsFullPath()}' with '{pattern}' pattern")
                .Then(new FoldPipe<Doc>(Doc.Merge, Doc.Empty).Logged(options.LoggerFactory, docs => $"Merge {docs.Length} files"))
                .Then(new InlineInheritDocPipe().Logged(options.LoggerFactory, "Inline <inheritdoc> tags")));
}