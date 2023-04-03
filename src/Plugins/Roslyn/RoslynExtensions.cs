using Summary.Pipelines;
using Summary.Pipes;
using Summary.Pipes.Filters;
using Summary.Pipes.IO;
using Summary.Roslyn.CSharp;

namespace Summary.Roslyn;

public static class RoslynExtensions
{
    public static SummaryPipeline UseRoslynParser(this SummaryPipeline self, string root, string pattern = "*.cs") =>
        self.ParseWith(
            new ScanDirectoryPipe(root, pattern)
                .ThenForEach(new ParseSyntaxTreePipe())
                .ThenForEach(new ParseDocPipe())
                .Then(new FoldPipe<Doc>(Doc.Merge))
                .Then(new InlineInheritDocPipe())
                .Then(new FilterPublicMembersPipe()));
}