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
    ///     The namespace the given syntax node is defined in.
    /// </summary>
    public static string? Namespace(this SyntaxNode self)
    {
        var parent = self.Parent;

        while (true)
        {
          if (parent is null)
            return null;
          if (parent is BaseNamespaceDeclarationSyntax @namespace)
            return @namespace.Name.ToString();

          parent = parent.Parent;
        }
    }

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
        TypeDeclarationSyntax x => $"{x.Identifier}{x.TypeParameterList.Formatted()}",
        MethodDeclarationSyntax x => $"{x.Identifier}{x.TypeParameterList.Formatted()}",
        VariableDeclaratorSyntax x => x.Identifier.Text,
        PropertyDeclarationSyntax x => x.Identifier.Text,
        ParameterSyntax x => x.Identifier.Text,
        EventDeclarationSyntax x => x.Identifier.Text,
        DelegateDeclarationSyntax x => x.Identifier.Text,
        IndexerDeclarationSyntax => "this",

        _ => null,
    };

    private static string Formatted(this TypeParameterListSyntax? self) =>
        (self?.Parameters ?? Enumerable.Empty<TypeParameterSyntax>())
        .Select(x => x.Identifier.Text)
        .Separated(with: ", ")
        .Surround("<", ">");

    /// <summary>
    ///     The source code location of the given syntax node.
    /// </summary>
    public static DocLocation? Location(this SyntaxNode self) =>
        self.GetLocation().Location();

    /// <summary>
    ///     The source code location of the given syntax token.
    /// </summary>
    public static DocLocation? Location(this SyntaxToken self) =>
        self.GetLocation().Location();

    private static DocLocation? Location(this Location location)
    {
        if (!string.IsNullOrWhiteSpace(location.SourceTree?.FilePath))
        {
            var line = location.GetLineSpan();
            var start = line.StartLinePosition;
            var end = line.EndLinePosition;

            return new DocLocation
            {
                Path = location.SourceTree.FilePath,
                Start = (start.Line, start.Character),
                End = (end.Line, end.Character),
            };
        }

        return null;
    }

    /// <summary>
    ///     The list of namespaces imported via <c>using</c> statement in the scope of the given node.
    /// </summary>
    public static string[] Usings(this SyntaxNode self) =>
        self.SyntaxTree
            .GetRoot()
            .DescendantNodesAndSelf()
            .OfType<UsingDirectiveSyntax>()
            .Select(x => x.Name?.ToString())
            .NonNulls()
            .Distinct()
            .ToArray();
}