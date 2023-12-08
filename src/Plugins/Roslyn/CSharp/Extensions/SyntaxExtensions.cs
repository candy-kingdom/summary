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

        var message = null as string;
        var error = false;

        if (attribute.ArgumentList?.Arguments.Count > 0)
        {
            var arguments = attribute.ArgumentList.Arguments;

            // `message` is the first positional argument.
            if (arguments[0] is { NameColon: null, NameEquals: null })
            {
                message = arguments[0].Expression.ToString();

                // `error` is the second positional or named argument.
                if (arguments.Count > 1 && arguments[1].NameEquals is null)
                    bool.TryParse(arguments[1].Expression.ToString(), out error);
            }
            else
            {
                message = Named(arguments, "message");

                bool.TryParse(Named(arguments, "error"), out error);

                static string? Named(SeparatedSyntaxList<AttributeArgumentSyntax> arguments, string name) =>
                    arguments
                        .FirstOrDefault(x => x.NameEquals?.Name.Identifier.ValueText == name)?
                        .Expression.ToString();
            }
        }

        return new DocDeprecation
        {
            Message = message,
            Error = error,
        };
    }

    /// <summary>
    ///     A list of attributes of the specified member formatted as a string.
    /// </summary>
    public static string Attributes(this MemberDeclarationSyntax self) =>
        self.AttributeLists.Attributes();

    /// <summary>
    ///     Formats the specified list of attributes.
    /// </summary>
    public static string Attributes(this SyntaxList<AttributeListSyntax> self) =>
        self
            .Select(x => $"{x}")
            .Separated(NewLine) is { } attributes and not ""
            ? $"{attributes}{NewLine}"
            : "";

    private static DocMember[] ToArray(this DocMember self) => new[] { self };
}