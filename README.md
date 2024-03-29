<div align="center">
    <img src="./res/icon-512.png" alt="Logo" width="128" height="128"></img>
</div>

<h1 align="center">&lt;summary&gt;</h1>

<p align="center">
    <i>Flexible and effortless API reference generator for .NET.</i>
</p>

<p align="center">
    <img alt="Nuget" src="https://img.shields.io/nuget/v/Summary">
</p>

## Usage

Currently, the generator is pretty young. In order to use it, you should download `Summary` (Core), `Summary.Roslyn` (Parser) and `Summary.Markdown` (Renderer) packages.

Here is a simple code-snippet that parses files in the specified directory and renders them into Markdown format:
```cs
// The folder you want to parse the `*.cs` files from.
const string input = "./src";

// The folder you want to put the generator output into.
const string output = "./docs";

await new SummaryPipeline()
    .UseRoslynParser(input)
    .UseMdRenderer(output)
    .UseDefaultFilters()
    .Run();
```

## Examples

Consider checking out the [docs](./docs) directory: it's the `Summary` summary generated by `Summary`. :sun_with_face:
