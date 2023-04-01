using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Summary.Extensions;

namespace Summary.Roslyn.CSharp.Extensions;

public static class TypeDeclarationExtensions
{
    public static string FullyQualifiedName(this TypeDeclarationSyntax self)
    {
        var name = new List<string>();
        var node = (SyntaxNode?) self;

        while (node != null)
        {
            var x = Name(node);
            if (x is not null)
                name.Insert(0, x);

            node = node.Parent;
        }

        return name.Separated(with: ".");

        string? Name(SyntaxNode x) => x switch
        {
            BaseNamespaceDeclarationSyntax n => n.Name.ToString(),
            TypeDeclarationSyntax t => t.Identifier.Text,

            _ => null,
        };
    }
}