using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Summary.Roslyn.CSharp.Extensions;

/// <summary>
///     A set of extension methods that help converting different syntax nodes into <see cref="DocField" />.
/// </summary>
internal static class FieldSyntaxExtensions
{
    /// <summary>
    ///     Converts the given field declaration into a sequence of <see cref="DocField" /> for each declared variable.
    /// </summary>
    public static DocField[] Fields(this FieldDeclarationSyntax self) =>
        self.Declaration.Variables.Select(x => x.Field(self)).ToArray();

    /// <summary>
    ///     Converts the given field declaration into <see cref="DocField" />.
    /// </summary>
    /// <remarks>
    ///     Only the first variable in the declaration is converted.
    /// </remarks>
    public static DocField Field(this FieldDeclarationSyntax self) =>
        self.Declaration.Variables[index: 0].Field(self);

    private static DocField Field(this VariableDeclaratorSyntax self, FieldDeclarationSyntax field) =>
        new()
        {
            Type = field.Declaration.Type.Type(),
            FullyQualifiedName = self.FullyQualifiedName(),
            Name = self.Name()!,
            Declaration = $"{field.AttributesDeclaration()}{field.Modifiers} {field.Declaration.Type} {self.Identifier}",
            Access = field.Access(),
            Comment = field.Comment(),
            DeclaringType = self.DeclaringType(),
            Deprecation = field.AttributeLists.Deprecation(),
        };
}