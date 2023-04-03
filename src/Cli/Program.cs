using Summary.Markdown;
using Summary.Pipelines;
using Summary.Roslyn;

const string input = "../../../../../";
const string output = "../../../../../docs";

await new SummaryPipeline()
    .UseRoslynParser(input)
    .UseMdRenderer(output)
    .Run();