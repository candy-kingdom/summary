using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Summary.Pipes;
using Summary.Pipes.IO;

namespace Summary.Roslyn.CSharp;

/// <summary>
///     A <see cref="IPipe{I,O}"/> that parses the specified string into a <see cref="SyntaxTree"/>.
/// </summary>
public class ParseSyntaxTreePipe : IPipe<Source, SyntaxTree>
{
    public Task<SyntaxTree> Run(Source input) =>
        Task.FromResult(SyntaxFactory.ParseSyntaxTree(input.Text, path: input.Path ?? ""));
}