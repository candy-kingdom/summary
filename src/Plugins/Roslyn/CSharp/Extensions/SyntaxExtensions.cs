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
    ///     Converts the specified syntax node to a document member.
    /// </summary>
    public static DocMember? Member(this SyntaxNode self, DocTypeDeclaration? parent = null) => self switch
    {
        TypeDeclarationSyntax x => x.TypeDeclaration(parent),
        FieldDeclarationSyntax x => x.Field(),
        PropertyDeclarationSyntax x => x.Property(),
        MethodDeclarationSyntax x => x.Method(),

        _ => null,
    };

    private static DocTypeDeclaration TypeDeclaration(this TypeDeclarationSyntax self, DocTypeDeclaration? parent = null)
    {
        var type = new DocTypeDeclaration(
            self.Identifier.Text,
            self.Declaration(),
            self.Access(),
            self.Comment(),
            null!,
            self.TypeParams(),
            parent,
            self.BaseList?.Types.Select(x => x.Type.Type()).ToArray() ?? System.Array.Empty<DocType>(),
            Record: self is RecordDeclarationSyntax);

        return type with { Members = self.Members(parent: type) };
    }

    private static DocType Type(this TypeDeclarationSyntax self) =>
        SyntaxFactory.ParseTypeName(self.Identifier.ValueText).Type();

    /// TODO: Handle `private int _x, _y` cases.
    private static DocField Field(this FieldDeclarationSyntax self) => new(
        self.Declaration.Type.Type(),
        self.Declaration.Variables[0].Identifier.Text,
        $"{self.Attributes()}{self.Modifiers} {self.Declaration}",
        self.Access(),
        self.Comment(),
        self.DeclaringType());

    private static DocProperty Property(this PropertyDeclarationSyntax self) => new(
        self.Type.Type(),
        self.Identifier.Text,
        $"{self.Attributes()}{self.Modifiers} {self.Type} {self.Identifier} {self.Accessors()}",
        self.Access(),
        self.Comment(),
        self.DeclaringType());

    private static DocProperty Property(this ParameterSyntax self, RecordDeclarationSyntax record) => new(
        // Record should always have parameters with types.
        self.Type!.Type(),
        self.Identifier.Text,
        $"{self.AttributeLists.Attributes()}public {self.Type} {self.Identifier} {{ get; }}",
        AccessModifier.Public,
        DocComment.Empty,
        self.DeclaringType(),
        Generated: true);

    private static DocMethod Method(this MethodDeclarationSyntax self) => new(
        self.Identifier.Text,
        $"{self.Attributes()}{self.Modifiers} {self.ReturnType} {self.Identifier}{self.TypeParameterList}{self.ParameterList}",
        self.Access(),
        self.Comment(),
        self.Params(),
        self.TypeParams(),
        self.DeclaringType());

    private static DocComment Comment(this MemberDeclarationSyntax self)
    {
        var nodes = self
            .GetLeadingTrivia()
            .Select(x => x.GetStructure())
            .OfType<DocumentationCommentTriviaSyntax>()
            .SelectMany(x => x.Content)
            .Nodes();

        return new(nodes);
    }

    private static AccessModifier Access(this MemberDeclarationSyntax self)
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

    private static string Accessors(this PropertyDeclarationSyntax self) =>
        self.AccessorList?.ToString() ?? "{ get; }";

    private static DocMember[] Members(this TypeDeclarationSyntax self, DocTypeDeclaration? parent = null) => self switch
    {
        RecordDeclarationSyntax record =>
            record
                .ParameterList?
                .Parameters
                .Select(x => x.Property(record))
                .Concat(self
                    .DescendantNodes()
                    .Select(x => Member(x, parent)))
                .NonNulls()
                .ToArray() ?? System.Array.Empty<DocMember>(),

        _ => self.DescendantNodes().Select(x => Member(x, parent)).NonNulls().ToArray(),
    };

    private static DocParam[] Params(this MethodDeclarationSyntax self) => self
        .ParameterList
        .Parameters
        .Select(x => x.Param(self))
        .ToArray();

    private static DocParam Param(this ParameterSyntax self, MemberDeclarationSyntax member) => new(
        self.Type?.Type(),
        self.Identifier.ValueText);

    private static DocTypeParam[] TypeParams(this TypeDeclarationSyntax self) => self
        .TypeParameterList?
        .TypeParams(self) ?? System.Array.Empty<DocTypeParam>();

    private static DocTypeParam[] TypeParams(this MethodDeclarationSyntax self) => self
        .TypeParameterList?
        .TypeParams(self) ?? System.Array.Empty<DocTypeParam>();

    private static DocTypeParam[] TypeParams(this TypeParameterListSyntax self, MemberDeclarationSyntax member) => self
        .Parameters
        .Select(x => x.TypeParam(member))
        .ToArray();

    private static DocTypeParam TypeParam(this TypeParameterSyntax self, MemberDeclarationSyntax member) => new(self.Identifier.ValueText);

    private static DocType Type(this TypeSyntax self) => self switch
    {
        PredefinedTypeSyntax x =>
            new DocType(x.Keyword.Text, System.Array.Empty<DocType>()),
        IdentifierNameSyntax x =>
            new DocType(x.Identifier.Text, System.Array.Empty<DocType>()),
        QualifiedNameSyntax x =>
            new DocType($"{x.Left}.{x.Right}", System.Array.Empty<DocType>()),
        GenericNameSyntax x =>
            new DocType(x.Identifier.Text, x.TypeArgumentList.Arguments.Select(y => y.Type()).ToArray()),
        TupleTypeSyntax x =>
            new DocType("Tuple", x.Elements.Select(y => y.Type.Type()).ToArray()),
        ArrayTypeSyntax x =>
            new DocType($"{x.ElementType}[]", System.Array.Empty<DocType>()),
        NullableTypeSyntax x =>
            new DocType($"{x.ElementType}?", new[] { x.ElementType.Type() }),
        _ =>
            throw new ArgumentOutOfRangeException($"Couldn't recognize syntax node: {self}"),
    };

    private static DocType? DeclaringType(this SyntaxNode self) =>
        self.FirstAncestorOrSelf<TypeDeclarationSyntax>()?.Type();

    private static string Declaration(this TypeDeclarationSyntax self) => self switch
    {
        RecordDeclarationSyntax record =>
            $"{self.Attributes()}{self.Modifiers} {record.Keyword()} {self.Identifier}{self.TypeParameterList}{record.ParameterList} {self.BaseList}".TrimEnd(),
        _ =>
            $"{self.Attributes()}{self.Modifiers} {self.Keyword} {self.Identifier}{self.TypeParameterList} {self.BaseList}".TrimEnd(),
    };

    private static string Attributes(this MemberDeclarationSyntax self) =>
        self.AttributeLists.Attributes();

    private static string Attributes(this SyntaxList<AttributeListSyntax> self) =>
        self
            .Select(x => $"{x}")
            .Separated(with: NewLine) is { } attributes and not ""
            ? $"{attributes}{NewLine}"
            : "";

    private static string Keyword(this RecordDeclarationSyntax self) =>
        self.ClassOrStructKeyword.Text is "" ? $"{self.Keyword}" : $"{self.Keyword} {self.ClassOrStructKeyword}";

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
                element.Content.Nodes()).Array(),

        XmlEmptyElementSyntax empty => empty.Name.ToString() switch
        {
            "see" => new DocCommentLink(empty.Cref()).Array(),
            "paramref" => new DocCommentParamRef(empty.Name()).Array(),
            "typeparamref" => new DocCommentParamRef(empty.Name()).Array(),
            "inheritdoc" => new DocCommentInheritDoc(empty.Cref()).Array(),

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

    // TODO: Probably need a better name.
    private static string Name(this XmlEmptyElementSyntax self) =>
        self.Attributes
            .OfType<XmlNameAttributeSyntax>()
            .Select(x => x.Identifier.ToString())
            .FirstOrDefault() ?? "";

    private static DocCommentElementAttribute? Attribute(this XmlAttributeSyntax self) => self switch
    {
        XmlNameAttributeSyntax name => new(self.Name.ToString(), name.Identifier.Identifier.ValueText),

        _ => null,
    };

    private static DocCommentNode[] Array<T>(this T self) where T : DocCommentNode => new[] { self };
}