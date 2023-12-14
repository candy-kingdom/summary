using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Summary.Extensions;
using static System.Environment;

namespace Summary.Roslyn.CSharp.Extensions;

/// <summary>
///     Generic extension methods that help building document members from Roslyn syntax nodes.
/// </summary>
internal static class SyntaxExtensions
{
    /// <summary>
    ///     Converts all child nodes of this node into a sequence of <see cref="DocMember" />.
    /// </summary>
    public static IEnumerable<DocMember> ChildMembers(this SyntaxNode self) =>
        self.ChildNodes().Select(x => x.Member()).NonNulls();

    /// <summary>
    ///     Converts the specified syntax node into a document member.
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
    public static IEnumerable<DocMember> Members(this SyntaxNode self) => self switch
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

    /// <summary>
    ///     Determines the access modifier (e.g., private, public, protected) of the given member.
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

        // Interface members without explicit access modifiers are considered public.
        if (self.Parent is InterfaceDeclarationSyntax)
            return AccessModifier.Public;

        return AccessModifier.Private;
    }

    /// <summary>
    ///     A <see cref="DocType" /> that represents the type this node is declared in.
    /// </summary>
    public static DocType? DeclaringType(this SyntaxNode self) =>
        self.Ancestors().OfType<TypeDeclarationSyntax>().FirstOrDefault()?.Type();

    /// <summary>
    ///     A <see cref="DocDeprecation"/> that contains the member deprecation information.
    /// </summary>
    public static DocDeprecation? Deprecation(this SyntaxList<AttributeListSyntax> self)
    {
        var attribute = self
            .SelectMany(x => x.Attributes)
            .FirstOrDefault(x => x.Name.ToString() is
                "Obsolete" or "System.Obsolete" or "global::System.Obsolete" or
                "ObsoleteAttribute" or "System.ObsoleteAttribute" or "global::System.ObsoleteAttribute");

        if (attribute is null)
            return null;

        return new DocDeprecation
        {
            Message = Message(attribute),
            Error = Error(attribute),
        };

        static string? Message(AttributeSyntax attribute)
        {
            var message = Argument(attribute, position: 0, name: "message")?.Expression.ToString();
            if (message is not null && message.StartsWith("\"") && message.EndsWith("\""))
                return message[1..^1];

            return message;
        }

        static bool Error(AttributeSyntax attribute)
        {
            var error = Argument(attribute, position: 1, name: "error")?.Expression.ToString();

            return bool.TryParse(error, out var parsed) && parsed;
        }

        static AttributeArgumentSyntax? Argument(AttributeSyntax attribute, int position, string name)
        {
            if (attribute.ArgumentList is null)
                return null;

            if (attribute.ArgumentList.Arguments.Count > position)
            {
                var argument = attribute.ArgumentList.Arguments[position];
                if (argument is { NameColon: null, NameEquals: null })
                    return argument;
            }

            return attribute.ArgumentList.Arguments.FirstOrDefault(
                x => x.NameColon?.Name.Identifier.ValueText == name);
        }
    }

    /// <summary>
    ///     A list of attributes of the specified member formatted as a string.
    /// </summary>
    public static string AttributesDeclaration(this MemberDeclarationSyntax self) =>
        self.AttributeLists.AttributesDeclaration();

    /// <summary>
    ///     Formats the specified list of attributes.
    /// </summary>
    public static string AttributesDeclaration(this SyntaxList<AttributeListSyntax> self) =>
        self
            .Select(x => $"{x}")
            .Separated(NewLine) is { } attributes and not ""
            ? $"{attributes}{NewLine}"
            : "";

    private static DocMember[] ToArray(this DocMember self) => new[] { self };
}