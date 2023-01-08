using Doc.Net.Core.Extensions;
using Doc.Net.Core.Pipes;
using Doc.Net.Roslyn.CSharp.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Document = Doc.Net.Core.Document;

namespace Doc.Net.Roslyn.CSharp;

/// <summary>
///     A <see cref="IPipe{I,O}"/> that transforms the specified syntax tree into parsed document.
/// </summary>
public class DocumentParserPipe : IPipe<SyntaxTree, Document>
{
    public async Task<Document> Run(SyntaxTree input)
    {
        var root = await input.GetRootAsync().ConfigureAwait(false);
        var members = root
            .DescendantNodes()
            .OfType<TypeDeclarationSyntax>()
            .Select(x => x.Member())
            .NonNulls()
            .ToArray();

        return new(members);
    }

}