using Summary;
using Summary.Markdown;
using Summary.Pipelines;
using Summary.Roslyn;

const string path = "../../../../../";
const string output = "../../../../../docs";

await new SummaryPipeline()
    .UseRoslynParser(path)
    .UseMdRenderer(output)
    .Run();