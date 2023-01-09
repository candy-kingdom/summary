using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Summary.Extensions;
using static System.Environment;
using DocumentationCommentTriviaSyntax = Microsoft.CodeAnalysis.CSharp.Syntax.DocumentationCommentTriviaSyntax;
using FieldDeclarationSyntax = Microsoft.CodeAnalysis.CSharp.Syntax.FieldDeclarationSyntax;
using XmlCrefAttributeSyntax = Microsoft.CodeAnalysis.CSharp.Syntax.XmlCrefAttributeSyntax;
using XmlElementSyntax = Microsoft.CodeAnalysis.CSharp.Syntax.XmlElementSyntax;
using XmlEmptyElementSyntax = Microsoft.CodeAnalysis.CSharp.Syntax.XmlEmptyElementSyntax;
using XmlNodeSyntax = Microsoft.CodeAnalysis.CSharp.Syntax.XmlNodeSyntax;
using XmlTextSyntax = Microsoft.CodeAnalysis.CSharp.Syntax.XmlTextSyntax;

namespace Summary.Roslyn.CSharp.Extensions;

/// <summary>
///     Extension methods for different Roslyn syntax nodes that helps constructing document members.
/// </summary>
internal static class SyntaxExtensions
{
    /// <summary>
    ///     The attributes formatted as a string of the specified member.
    /// </summary>
    public static string Attributes(this MemberDeclarationSyntax self) =>
        self
            .AttributeLists
            .Select(x => $"{x}")
            .Separated(with: NewLine) is { } attributes and not ""
            ? $"{attributes}{NewLine}"
            : "";

    /// <summary>
    ///     The access modifier of the specified member.
    /// </summary>
    public static AccessModifier Access(this MemberDeclarationSyntax self)
    {
        if (self.Modifiers.Any(SyntaxKind.PublicKeyword))
            return AccessModifier.Public;
        if (self.Modifiers.Any(SyntaxKind.ProtectedKeyword))
            return AccessModifier.Protected;
        if (self.Modifiers.Any(SyntaxKind.InternalKeyword))
            return AccessModifier.Internal;
        if (self.Modifiers.Any(SyntaxKind.PrivateKeyword))
            return AccessModifier.Private;

        return AccessModifier.Private;
    }

    /// <summary>
    ///     Formatted accessors (e.g. `{ get; set; }`, `{ get; init }`, etc.) of the specified property.
    /// </summary>
    public static string Accessors(this PropertyDeclarationSyntax self) =>
        self.AccessorList?.ToString() ?? "{ get; }";

    /// <summary>
    ///     Parses document members from the specified syntax node.
    /// </summary>
    /// TODO: Fix nested types.
    public static DocMember[] Members(this SyntaxNode self) =>
        self.DescendantNodes().Select(Member).NonNulls().ToArray();

    /// <summary>
    ///     Converts the specified syntax node to a document member.
    /// </summary>
    public static DocMember? Member(this SyntaxNode self) => self switch
    {
        TypeDeclarationSyntax x => x.Type(),
        FieldDeclarationSyntax x => x.Field(),
        PropertyDeclarationSyntax x => x.Property(),
        MethodDeclarationSyntax x => x.Method(),

        _ => null,
    };

    /// <summary>
    ///     Parses the specified syntax node to a document type.
    /// </summary>
    public static DocType Type(this TypeDeclarationSyntax self) => new(
        self.Identifier.Text,
        self.Declaration(),
        self.Access(),
        self.Comment(),
        self.Members());

    private static string Declaration(this TypeDeclarationSyntax self) => self switch
    {
        RecordDeclarationSyntax record =>
            $"{self.Attributes()}{self.Modifiers} {record.Keyword()} {self.Identifier}{self.TypeParameterList}{record.ParameterList} {self.BaseList}".TrimEnd(),
        _ =>
            $"{self.Attributes()}{self.Modifiers} {self.Keyword} {self.Identifier}{self.TypeParameterList} {self.BaseList}".TrimEnd(),
    };

    private static string Keyword(this RecordDeclarationSyntax self) =>
        self.ClassOrStructKeyword.Text is "" ? $"{self.Keyword}" : $"{self.Keyword} {self.ClassOrStructKeyword}";

    /// <summary>
    ///     Parses the specified syntax node to a document field.
    /// </summary>
    /// TODO: Handle `private int _x, _y` cases.
    public static DocField Field(this FieldDeclarationSyntax self) => new(
        self.Declaration.Variables[0].Identifier.Text,
        $"{self.Attributes()}{self.Modifiers} {self.Declaration}",
        self.Access(),
        self.Comment());

    /// <summary>
    ///     Parses the specified syntax node to a document property.
    /// </summary>
    public static DocProperty Property(this PropertyDeclarationSyntax self) => new(
        self.Identifier.Text,
        $"{self.Attributes()}{self.Modifiers} {self.Type} {self.Identifier} {self.Accessors()}",
        self.Access(),
        self.Comment());

    /// <summary>
    ///     Parses the specified syntax node to a document method.
    /// </summary>
    public static DocMethod Method(this MethodDeclarationSyntax self) => new(
        self.Identifier.Text,
        $"{self.Attributes()}{self.Modifiers} {self.ReturnType} {self.Identifier}{self.TypeParameterList}{self.ParameterList}",
        self.Access(),
        self.Comment());

    /// <summary>
    ///     Parses the documentation comment of the specified member.
    /// </summary>
    public static DocComment Comment(this MemberDeclarationSyntax self)
    {
        var nodes = self
            .GetLeadingTrivia()
            .Select(x => x.GetStructure())
            .OfType<DocumentationCommentTriviaSyntax>()
            .SelectMany(x => x.Content)
            .Nodes();

        return new(nodes);
    }

    private static DocCommentNode[] Nodes(this IEnumerable<XmlNodeSyntax> self) =>
        self.SelectMany(Nodes).ToArray();

    private static DocCommentNode[] Nodes(this XmlNodeSyntax xml) => xml switch
    {
        XmlTextSyntax text => text.TextTokens.Select(Literal).ToArray(),
        XmlElementSyntax element => new DocCommentElement(element.StartTag.Name.ToString(), element.Content.Nodes()).Array(),
        XmlEmptyElementSyntax empty => empty.Name.ToString() switch
        {
            "see" => new DocCommentLink(empty.Cref()).Array(),

            _ => DocCommentLiteral.New(empty.ToString()).Array(),
        },

        _ => DocCommentLiteral.New(xml.ToString()).Array(),
    };

    private static DocCommentNode Literal(this SyntaxToken token) => token.Kind() switch
    {
        SyntaxKind.XmlTextLiteralNewLineToken => new DocCommentLiteral(NewLine),

        _ => DocCommentLiteral.New(token.ValueText),
    };

    private static string Cref(this XmlEmptyElementSyntax self) =>
        self.Attributes
            .OfType<XmlCrefAttributeSyntax>()
            .Select(x => x.Cref.ToString())
            .FirstOrDefault() ?? "";

    private static DocCommentNode[] Array<T>(this T self) where T : DocCommentNode => new[] { self };
}