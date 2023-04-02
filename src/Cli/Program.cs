using Summary;
using Summary.Markdown;
using Summary.Roslyn;

const string path = "../../../../../";
const string output = "../../../../../docs";

await new SummaryGen()
    .UseRoslynParser(path)
    .UseMdRenderer(output)
    .Run();