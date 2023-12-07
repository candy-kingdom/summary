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
    /// <inheritdoc cref="UseRoslynParser(SummaryPipeline,string[],string)"/>
    public static SummaryPipeline UseRoslynParser(this SummaryPipeline self, string source, string pattern = "*.cs") =>
        self.UseRoslynParser(new[] { source }, pattern);

    /// <summary>
    ///     Adds a Roslyn parser to the specified pipeline.
    /// </summary>
    /// <remarks>
    ///     This parser will parse all the C# files in the specified directory
    ///     and will extract comments from the corresponding syntax trees using Roslyn API.
    ///     <para/>
    ///     Under the hood, we call <see cref="System.IO.Directory.EnumerateFiles(string,string,SearchOption)"/> method
    ///     to get the list of all files for each of the specified root paths, and then concatenate the results.
    /// </remarks>
    public static SummaryPipeline UseRoslynParser(this SummaryPipeline self, string[] sources, string pattern = "*.cs") =>
        self.ParseWith(options =>
            new ScanDirectoryPipe(sources, pattern)
                .ThenForEach(new ParseSyntaxTreePipe())
                .ThenForEach(new ParseDocPipe())
                .Logged(options.LoggerFactory, $"Parse directories [{sources.Select(x => $"'{x.AsFullPath()}'").Separated(with: ", ")}] with '{pattern}' pattern")
                .Then(new FoldPipe<Doc>(Doc.Merge, Doc.Empty).Logged(options.LoggerFactory, docs => $"Merge {docs.Length} files"))
                .Then(new InlineInheritDocPipe().Logged(options.LoggerFactory, "Inline <inheritdoc> tags")));
}