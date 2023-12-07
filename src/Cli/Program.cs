using Summary.Cli.Logging;
using Summary.Markdown;
using Summary.Pipelines;
using Summary.Roslyn;

const string input = "../../../../../src/";
const string output = "../../../../../docs";

var options = new SummaryPipeline.Options().UseLoggerFactory(new ConsoleLoggerFactory());

await new SummaryPipeline(options)
    .UseRoslynParser(input)
    .UseMdRenderer(output)
    .Run();