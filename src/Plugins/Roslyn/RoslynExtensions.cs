using Summary.Pipes;
using Summary.Pipes.Filters;
using Summary.Pipes.IO;
using Summary.Roslyn.CSharp;

namespace Summary.Roslyn;

public static class RoslynExtensions
{
    public static SummaryGen UseRoslynParser(this SummaryGen self, string root, string pattern = "*.cs") =>
        self.ParseWith(
            new ScanDirectoryPipe(root, pattern)
                .ThenForEach(new ParseSyntaxTreePipe())
                .ThenForEach(new ParseDocPipe())
                .Then(new InlineInheritDocPipe())
                .Then(new FilterPublicMembersPipe()));
}