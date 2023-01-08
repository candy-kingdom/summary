using Doc.Net.Core;
using Doc.Net.Core.IO;
using Doc.Net.Core.Pipes;
using Doc.Net.Roslyn.CSharp;
using Net.Core.Markdown;

const string path = "../../../../../";
const string output = "../../../../../docs";

await new DirectoryScannerPipe(path, "*.cs")
    .ThenForAll(new SyntaxTreeParserPipe())
    .ThenForAll(new DocumentParserPipe())
    .Flatten(Document.Merge)
    .Then(new MarkdownRenderPipe())
    .ThenForAll(new SavePipe<Markdown>(output, x => (x.Name, x.Content)))
    .Run();