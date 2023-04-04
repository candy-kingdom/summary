using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Summary.Extensions;
using Summary.Pipes;
using Summary.Roslyn.CSharp.Extensions;

namespace Summary.Roslyn.CSharp;

/// <summary>
///     A <see cref="IPipe{I,O}" /> that transforms the specified syntax tree into parsed document.
/// </summary>
public class ParseDocPipe : IPipe<SyntaxTree, Doc>
{
    public async Task<Doc> Run(SyntaxTree input)
    {
        var root = await input.GetRootAsync().ConfigureAwait(continueOnCapturedContext: false);
        var members = root
            .ChildMembers()
            .Concat(root
                .ChildNodes()
                .OfType<BaseNamespaceDeclarationSyntax>()
                .SelectMany(x => x.ChildMembers()))
            .NonNulls()
            .ToArray();

        return new Doc(members);
    }
}