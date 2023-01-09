using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Summary.Pipes;

namespace Summary.Roslyn.CSharp;

/// <summary>
///     A <see cref="IPipe{I,O}"/> that parses the specified string into a <see cref="SyntaxTree"/>.
/// </summary>
public class ParseSyntaxTreePipe : IPipe<string, SyntaxTree>
{
    public Task<SyntaxTree> Run(string input) =>
        Task.FromResult(SyntaxFactory.ParseSyntaxTree(input));
}