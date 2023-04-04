using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Summary.Extensions;

namespace Summary.Roslyn.CSharp.Extensions;

/// <summary>
///     A set of common extension methods that extend <see cref="SyntaxNode" /> and are not related to Summary API.
/// </summary>
internal static class SyntaxNodeExtensions
{
    /// <summary>
    ///     A fully qualified name of the specified syntax node.
    /// </summary>
    public static string FullyQualifiedName(this SyntaxNode self)
    {
        var name = new List<string>();
        var node = (SyntaxNode?) self;

        while (node != null)
        {
            var x = node.Name();
            if (x is not null)
                name.Insert(index: 0, x);

            node = node.Parent;
        }

        return name.Separated(".");
    }

    /// <summary>
    ///     A short name of the specified syntax node.
    /// </summary>
    public static string? Name(this SyntaxNode self) => self switch
    {
        BaseNamespaceDeclarationSyntax x => x.Name.ToString(),
        TypeDeclarationSyntax x => x.Identifier.Text,
        VariableDeclaratorSyntax x => x.Identifier.Text,
        PropertyDeclarationSyntax x => x.Identifier.Text,
        ParameterSyntax x => x.Identifier.Text,
        EventDeclarationSyntax x => x.Identifier.Text,
        MethodDeclarationSyntax x => x.Identifier.Text,
        DelegateDeclarationSyntax x => x.Identifier.Text,
        IndexerDeclarationSyntax => "this",

        _ => null,
    };
}