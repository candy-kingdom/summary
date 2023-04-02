using Summary.Markdown;
using Summary.Pipes;
using Summary.Pipes.Filters;
using Summary.Pipes.IO;
using Summary.Roslyn.CSharp;

const string path = "../../../../../";
const string output = "../../../../../docs";

// await new ScanDirectoryPipe(path, "*.cs")
await new ScanDirectoryPipe(path, "InheritDoc*.cs")
    .ThenForEach(new ParseSyntaxTreePipe())
    .ThenForEach(new ParseDocPipe())
    .Then(new InlineInheritDocPipe())
    .Then(new FilterPublicMembersPipe())
    .Then(new RenderMarkdownPipe())
    .ThenForEach(new SavePipe<Md>(output, x => (x.Name, x.Content)))
    .Run();