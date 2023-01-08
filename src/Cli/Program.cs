using Summary;
using Summary.Markdown;
using Summary.Pipes;
using Summary.Pipes.Filters;
using Summary.Pipes.IO;
using Summary.Roslyn.CSharp;

const string path = "../../../../../";
const string output = "../../../../../docs";

await new DirectoryScannerPipe(path, "*.cs")
    .ThenForAll(new SyntaxTreeParserPipe())
    .ThenForAll(new DocumentParserPipe())
    .Flatten(Doc.Merge)
    .Then(new PublicFilterPipe())
    .Then(new MarkdownRenderPipe())
    .ThenForAll(new SavePipe<Markdown>(output, x => (x.Name, x.Content)))
    .Run();