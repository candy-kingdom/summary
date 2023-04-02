using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Summary.Extensions;
using Summary.Pipes;
using Summary.Roslyn.CSharp.Extensions;

namespace Summary.Roslyn.CSharp;

/// <summary>
///     A <see cref="IPipe{I,O}"/> that transforms the specified syntax tree into parsed document.
/// </summary>
public class ParseDocPipe : IPipe<SyntaxTree, Doc>
{
    public async Task<Doc> Run(SyntaxTree input)
    {
        var root = await input.GetRootAsync().ConfigureAwait(false);
        var members = root
            .ChildNodes()
            .OfType<TypeDeclarationSyntax>()
            .Select(x => x.Member())
            .Concat(root
                .ChildNodes()
                .OfType<BaseNamespaceDeclarationSyntax>()
                .SelectMany(x => x
                    .ChildNodes()
                    .OfType<TypeDeclarationSyntax>()
                    .Select(y => y.Member())
                    .Concat(x.ChildNodes().OfType<DelegateDeclarationSyntax>().Select(y => y.Member()))))
            .Concat(root.ChildNodes().OfType<DelegateDeclarationSyntax>().Select(x => x.Member()))
            .NonNulls()
            .ToArray();

        return new(members);
    }
}