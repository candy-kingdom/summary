﻿using Summary.Cli.Logging;
using Summary.Markdown;
using Summary.Pipelines;
using Summary.Roslyn;

const string input = "../../../../../";
const string output = "../../../../../docs";

await new SummaryPipeline()
    .UseLoggerFactory(new ConsoleLoggerFactory())
    .UseRoslynParser(input)
    .UseMdRenderer(output)
    .Run();