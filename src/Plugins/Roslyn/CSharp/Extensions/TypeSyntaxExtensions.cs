using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Summary.Roslyn.CSharp.Extensions;

/// <summary>
///     A set of extension methods that help converting different syntax nodes into <see cref="DocType" />.
/// </summary>
internal static class TypeSyntaxExtensions
{
    /// <summary>
    ///     Converts the given type declaration into <see cref="DocType" />.
    /// </summary>
    public static DocType Type(this TypeDeclarationSyntax self) =>
        SyntaxFactory.ParseTypeName(self.Identifier.ValueText).Type();

    /// <summary>
    ///     Converts the given type syntax into <see cref="DocType" />.
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     The type syntax is not one of the known types (e.g., nullable, generic, tuple, etc.).
    /// </exception>
    public static DocType Type(this TypeSyntax self) => self switch
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
}