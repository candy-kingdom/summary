using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Summary.Extensions;
using static System.Environment;

namespace Summary.Roslyn.CSharp.Extensions;

/// <summary>
///     Extension methods for different Roslyn syntax nodes that helps constructing document members.
/// </summary>
internal static class SyntaxExtensions
{
    /// <summary>
    ///     Converts the specified syntax node to a document member.
    /// </summary>
    public static DocMember? Member(this SyntaxNode self) => self switch
    {
        TypeDeclarationSyntax x => x.TypeDeclaration(),
        FieldDeclarationSyntax x => x.Field(),
        PropertyDeclarationSyntax x => x.Property(),
        EventDeclarationSyntax x => x.Property(),
        EventFieldDeclarationSyntax x => x.Property(),
        IndexerDeclarationSyntax x => x.Indexer(),
        DelegateDeclarationSyntax x => x.Delegate(),
        MethodDeclarationSyntax x => x.Method(),

        _ => null,
    };

    /// <summary>
    ///     Converts the specified syntax node into an array of doc members.
    /// </summary>
    /// <remarks>
    ///     Fields and field-events can be represented as more than one member.
    /// </remarks>
    private static IEnumerable<DocMember> Members(this SyntaxNode self) => self switch
    {
        TypeDeclarationSyntax x => x.TypeDeclaration().ToArray(),
        FieldDeclarationSyntax x => x.Fields(),
        PropertyDeclarationSyntax x => x.Property().ToArray(),
        EventDeclarationSyntax x => x.Property().ToArray(),
        EventFieldDeclarationSyntax x => x.Properties(),
        IndexerDeclarationSyntax x => x.Indexer().ToArray(),
        DelegateDeclarationSyntax x => x.Delegate().ToArray(),
        MethodDeclarationSyntax x => x.Method().ToArray(),

        _ => Enumerable.Empty<DocMember>(),
    };

    private static DocTypeDeclaration TypeDeclaration(this TypeDeclarationSyntax self) =>
        new()
        {
            FullyQualifiedName = self.FullyQualifiedName(),
            Name = self.Name()!,
            Declaration = self.Declaration(),
            Access = self.Access(),
            Comment = self.Comment(),
            DeclaringType = self.DeclaringType(),
            Members = self.Members(),
            TypeParams = self.TypeParams(),
            Base = self.BaseList?.Types.Select(x => x.Type.Type()).ToArray() ?? Array.Empty<DocType>(),
            Record = self is RecordDeclarationSyntax,
        };

    private static DocField[] Fields(this FieldDeclarationSyntax self) =>
        self.Declaration.Variables.Select(x => x.Field(self)).ToArray();

    private static DocField Field(this FieldDeclarationSyntax self) =>
        self.Declaration.Variables[index: 0].Field(self);

    private static DocField Field(this VariableDeclaratorSyntax self, FieldDeclarationSyntax field) =>
        new()
        {
            Type = field.Declaration.Type.Type(),
            FullyQualifiedName = self.FullyQualifiedName(),
            Name = self.Name()!,
            Declaration = $"{field.Attributes()}{field.Modifiers} {field.Declaration.Type} {self.Identifier}",
            Access = field.Access(),
            Comment = field.Comment(),
            DeclaringType = self.DeclaringType(),
        };

    private static DocProperty Property(this PropertyDeclarationSyntax self) =>
        new()
        {
            Type = self.Type.Type(),
            FullyQualifiedName = self.FullyQualifiedName(),
            Name = self.Name()!,
            Declaration = $"{self.Attributes()}{self.Modifiers} {self.Type} {self.Identifier} {self.Accessors()}",
            Access = self.Access(),
            Comment = self.Comment(),
            DeclaringType = self.DeclaringType(),
            Generated = false,
            Event = false,
        };

    private static DocProperty Property(this ParameterSyntax self) =>
        new()
        {
            Type = self.Type!.Type(),
            FullyQualifiedName = self.FullyQualifiedName(),
            Name = self.Name()!,
            Declaration = $"{self.AttributeLists.Attributes()}public {self.Type} {self.Identifier} {{ get; }}",
            Access = AccessModifier.Public,
            Comment = DocComment.Empty,
            DeclaringType = self.DeclaringType(),
            Generated = true,
            Event = false,
        };

    private static DocProperty Property(this EventDeclarationSyntax self) =>
        new()
        {
            Type = self.Type!.Type(),
            FullyQualifiedName = self.FullyQualifiedName(),
            Name = self.Name()!,
            Declaration = $"{self.Attributes()}{self.Modifiers} {self.Type} {self.Identifier} {self.Accessors()}",
            Access = self.Access(),
            Comment = self.Comment(),
            DeclaringType = self.DeclaringType(),
            Generated = false,
            Event = true,
        };

    private static DocProperty[] Properties(this EventFieldDeclarationSyntax self) =>
        self.Declaration.Variables.Select(x => x.Property(self)).ToArray();

    private static DocProperty Property(this EventFieldDeclarationSyntax self) =>
        self.Declaration.Variables[index: 0].Property(self);

    private static DocProperty Property(this VariableDeclaratorSyntax self, EventFieldDeclarationSyntax field) =>
        new()
        {
            Type = field.Declaration.Type.Type(),
            FullyQualifiedName = self.FullyQualifiedName(),
            Name = self.Name()!,
            Declaration = $"{field.Attributes()}{field.Modifiers} event {field.Declaration.Type} {self.Identifier}",
            Access = field.Access(),
            Comment = field.Comment(),
            DeclaringType = self.DeclaringType(),
            Generated = false,
            Event = true,
        };

    private static DocIndexer Indexer(this IndexerDeclarationSyntax self) =>
        new()
        {
            Type = self.Type.Type(),
            FullyQualifiedName = self.FullyQualifiedName(),
            Name = self.Name()!,
            Declaration = $"{self.Attributes()}{self.Modifiers} {self.Type} this{self.ParameterList} {self.Accessors()}",
            Access = self.Access(),
            Comment = self.Comment(),
            DeclaringType = self.DeclaringType(),
            Generated = false,
            Event = false,
            Params = self.Params(),
        };

    private static DocMethod Method(this MethodDeclarationSyntax self) =>
        new()
        {
            FullyQualifiedName = self.FullyQualifiedName(),
            Name = self.Name()!,
            Declaration =
                $"{self.Attributes()}{self.Modifiers} {self.ReturnType} {self.Identifier}{self.TypeParameterList}{self.ParameterList}",
            Access = self.Access(),
            Comment = self.Comment(),
            DeclaringType = self.DeclaringType(),
            Params = self.Params(),
            TypeParams = self.TypeParams(),
            Delegate = false,
        };

    private static DocMethod Delegate(this DelegateDeclarationSyntax self) => new()
    {
        FullyQualifiedName = self.FullyQualifiedName(),
        Name = self.Name()!,
        Declaration =
            $"{self.Attributes()}{self.Modifiers} {self.ReturnType} {self.Identifier}{self.TypeParameterList}{self.ParameterList}",
        Access = self.Access(),
        Comment = self.Comment(),
        Params = self.Params(),
        TypeParams = self.TypeParams(),
        DeclaringType = self.DeclaringType(),
        Delegate = true,
    };

    private static DocComment Comment(this MemberDeclarationSyntax self)
    {
        var nodes = self
            .GetLeadingTrivia()
            .Select(x => x.GetStructure())
            .OfType<DocumentationCommentTriviaSyntax>()
            .SelectMany(x => x.Content)
            .Nodes();

        return new DocComment(nodes);
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
        self.AccessorList?.Accessors() ?? "{ get; }";

    private static string Accessors(this IndexerDeclarationSyntax self) =>
        self.AccessorList?.Accessors() ?? "{ get; }";

    private static string Accessors(this EventDeclarationSyntax self) =>
        self.AccessorList?.Accessors() ?? "{ add; remove; }";

    private static string Accessors(this AccessorListSyntax self) =>
        $"{{ {self.Accessors.Select(x => $"{x.Modifiers.ToString().Space()}{x.Keyword}; ").Separated("")}}}";

    private static DocMember[] Members(this TypeDeclarationSyntax self) => self switch
    {
        RecordDeclarationSyntax record =>
            self
                .DescendantNodes()
                .SelectMany(Members)
                .Concat(record
                    .ParameterList?
                    .Parameters
                    .Select(x => x.Property()) ?? Enumerable.Empty<DocMember>())
                .NonNulls()
                .ToArray(),

        _ => self.DescendantNodes().SelectMany(Members).NonNulls().ToArray(),
    };

    private static DocParam[] Params(this MethodDeclarationSyntax self) =>
        self.ParameterList.Params();

    private static DocParam[] Params(this IndexerDeclarationSyntax self) =>
        self.ParameterList.Params();

    private static DocParam[] Params(this DelegateDeclarationSyntax self) =>
        self.ParameterList.Params();

    private static DocParam[] Params(this BaseParameterListSyntax self) => self
        .Parameters
        .Select(x => x.Param())
        .ToArray();

    private static DocParam Param(this ParameterSyntax self) => new(
        self.Type?.Type(),
        self.Identifier.ValueText);

    private static DocTypeParam[] TypeParams(this TypeDeclarationSyntax self) =>
        self.TypeParameterList.TypeParams();

    private static DocTypeParam[] TypeParams(this MethodDeclarationSyntax self) =>
        self.TypeParameterList.TypeParams();

    private static DocTypeParam[] TypeParams(this DelegateDeclarationSyntax self) =>
        self.TypeParameterList.TypeParams();

    private static DocTypeParam[] TypeParams(this TypeParameterListSyntax? self) => self?
        .Parameters
        .Select(x => x.TypeParam())
        .ToArray() ?? Array.Empty<DocTypeParam>();

    private static DocTypeParam TypeParam(this TypeParameterSyntax self) => new(self.Identifier.ValueText);

    private static DocType Type(this TypeSyntax self) => self switch
    {
        PredefinedTypeSyntax x =>
            new DocType(x.Keyword.Text, Array.Empty<DocType>()),
        IdentifierNameSyntax x =>
            new DocType(x.Identifier.Text, Array.Empty<DocType>()),
        QualifiedNameSyntax x =>
            new DocType($"{x.Left}.{x.Right}", Array.Empty<DocType>()),
        GenericNameSyntax x =>
            new DocType(x.Identifier.Text, x.TypeArgumentList.Arguments.Select(y => y.Type()).ToArray()),
        TupleTypeSyntax x =>
            new DocType("Tuple", x.Elements.Select(y => y.Type.Type()).ToArray()),
        ArrayTypeSyntax x =>
            new DocType($"{x.ElementType}[]", Array.Empty<DocType>()),
        NullableTypeSyntax x =>
            new DocType($"{x.ElementType}?", new[] { x.ElementType.Type() }),
        _ =>
            throw new ArgumentOutOfRangeException($"Couldn't recognize syntax node: {self}"),
    };

    private static DocType? DeclaringType(this SyntaxNode self) =>
        self.FirstAncestorOrSelf<TypeDeclarationSyntax>()?.Type();

    private static DocType Type(this TypeDeclarationSyntax self) =>
        SyntaxFactory.ParseTypeName(self.Identifier.ValueText).Type();

    private static string Declaration(this TypeDeclarationSyntax self) => self switch
    {
        RecordDeclarationSyntax record =>
            $"{self.Attributes()}{self.Modifiers} {record.Keyword()} {self.Identifier}{self.TypeParameterList}{record.ParameterList} {self.BaseList}"
                .TrimEnd(),
        _ =>
            $"{self.Attributes()}{self.Modifiers} {self.Keyword} {self.Identifier}{self.TypeParameterList} {self.BaseList}"
                .TrimEnd(),
    };

    private static string Attributes(this MemberDeclarationSyntax self) =>
        self.AttributeLists.Attributes();

    private static string Attributes(this SyntaxList<AttributeListSyntax> self) =>
        self
            .Select(x => $"{x}")
            .Separated(NewLine) is { } attributes and not ""
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
        SyntaxKind.XmlTextLiteralNewLineToken => new DocCommentLiteral(NewLine),

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

        _ => null,
    };

    private static DocMember[] ToArray(this DocMember self) => new[] { self };
    private static DocCommentNode[] ToArray(this DocCommentNode self) => new[] { self };
}