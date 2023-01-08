using Doc.Net.Core.Pipes;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Doc.Net.Roslyn.CSharp;

/// <summary>
///     A <see cref="IPipe{I,O}"/> that parses the specified string into a <see cref="SyntaxTree"/>.
/// </summary>
public class SyntaxTreeParserPipe : IPipe<string, SyntaxTree>
{
    public Task<SyntaxTree> Run(string input) =>
        Task.FromResult(SyntaxFactory.ParseSyntaxTree(input));
}