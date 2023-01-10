using Summary;
using Summary.Markdown;
using Summary.Pipes;
using Summary.Pipes.Filters;
using Summary.Pipes.IO;
using Summary.Roslyn.CSharp;

const string path = "../../../../../";
const string output = "../../../../../docs";

await new ScanDirectoryPipe(path, "*.cs")
    .ThenForEach(new ParseSyntaxTreePipe())
    .ThenForEach(new ParseDocPipe())
    .Then(new FoldPipe<Doc>(Doc.Merge))
    .Then(new FilterPublicMembersPipe())
    .Then(new RenderMarkdownPipe())
    .ThenForEach(new SavePipe<Md>(output, x => (x.Name, x.Content)))
    .Run();