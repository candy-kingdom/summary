using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Summary.Extensions;

namespace Summary.Roslyn.CSharp.Extensions;

/// <summary>
///     A set of extension methods that help parsing XML documentation comments
///     into <see cref="DocComment" /> and <see cref="DocCommentNode" />.
/// </summary>
internal static class XmlSyntaxExtensions
{
    /// <summary>
    ///     Parses XML documentation from the specified member into <see cref="DocComment" /> object.
    /// </summary>
    public static DocComment Comment(this MemberDeclarationSyntax self)
    {
        var nodes = self
            .GetLeadingTrivia()
            .Select(x => x.GetStructure())
            .OfType<DocumentationCommentTriviaSyntax>()
            .SelectMany(x => x.Content)
            .Nodes();

        return new DocComment(nodes);
    }

    private static DocCommentNode[] Nodes(this IEnumerable<XmlNodeSyntax> self) =>
        self.SelectMany(Nodes).ToArray();

    private static DocCommentNode[] Nodes(this XmlNodeSyntax xml) => xml switch
    {
        XmlTextSyntax text =>
            text.TextTokens.Select(Literal).ToArray(),

        XmlElementSyntax element =>
            new DocCommentElement(
                    element.StartTag.Name.ToString(),
                    element.StartTag.Attributes.Select(x => x.Attribute()).NonNulls().ToArray(),
                    element.Content.Nodes())
                .ToArray(),

        XmlEmptyElementSyntax empty => empty.Name.ToString() switch
        {
            "see" => new DocCommentLink(empty.Cref()).ToArray(),
            "paramref" => new DocCommentParamRef(empty.Name()).ToArray(),
            "typeparamref" => new DocCommentParamRef(empty.Name()).ToArray(),
            "inheritdoc" => new DocCommentInheritDoc(empty.Cref()).ToArray(),

            _ => DocCommentLiteral.New(empty.ToString()).ToArray(),
        },

        _ => DocCommentLiteral.New(xml.ToString()).ToArray(),
    };

    private static DocCommentNode Literal(this SyntaxToken token) => token.Kind() switch
    {
        SyntaxKind.XmlTextLiteralNewLineToken => new DocCommentLiteral(Environment.NewLine),

        _ => DocCommentLiteral.New(token.ValueText),
    };

    private static string Cref(this XmlEmptyElementSyntax self) =>
        self.Attributes
            .OfType<XmlCrefAttributeSyntax>()
            .Select(x => x.Cref.ToString())
            .FirstOrDefault() ?? "";

    private static string Name(this XmlEmptyElementSyntax self) =>
        self.Attributes
            .OfType<XmlNameAttributeSyntax>()
            .Select(x => x.Identifier.ToString())
            .FirstOrDefault() ?? "";

    private static DocCommentElementAttribute? Attribute(this XmlAttributeSyntax self) => self switch
    {
        XmlNameAttributeSyntax name => new DocCommentElementAttribute(self.Name.ToString(), name.Identifier.Identifier.ValueText),
        XmlCrefAttributeSyntax cref => new DocCommentElementAttribute(self.Name.ToString(), cref.Cref.ToString()),
        _ => null,
    };

    private static DocCommentNode[] ToArray(this DocCommentNode self) => new[] { self };
}