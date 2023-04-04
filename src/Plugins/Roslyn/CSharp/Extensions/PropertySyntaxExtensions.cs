using Microsoft.CodeAnalysis.CSharp.Syntax;
using Summary.Extensions;

namespace Summary.Roslyn.CSharp.Extensions;

/// <summary>
///     A set of extension methods that help converting different syntax nodes into <see cref="DocProperty" />.
/// </summary>
internal static class PropertySyntaxExtensions
{
    /// <summary>
    ///     Converts the given event field declaration into a sequence of <see cref="DocProperty" /> for each declared variable.
    /// </summary>
    public static DocProperty[] Properties(this EventFieldDeclarationSyntax self) =>
        self.Declaration.Variables.Select(x => x.Property(self)).ToArray();

    /// <summary>
    ///     Converts the given property declaration into <see cref="DocProperty" />.
    /// </summary>
    public static DocProperty Property(this PropertyDeclarationSyntax self) =>
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

    /// <summary>
    ///     Converts the given parameter node into <see cref="DocProperty" />.
    /// </summary>
    /// <remarks>
    ///     It makes sense to convert a parameter node into a property if it's a record property declared as a parameter.
    /// </remarks>
    public static DocProperty Property(this ParameterSyntax self) =>
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

    /// <summary>
    ///     Converts the given event property declaration into <see cref="DocProperty" />.
    /// </summary>
    public static DocProperty Property(this EventDeclarationSyntax self) =>
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

    /// <summary>
    ///     Converts the given event field declaration into <see cref="DocProperty" />.
    /// </summary>
    /// <remarks>
    ///     Only the first variable in the declaration is converted.
    /// </remarks>
    public static DocProperty Property(this EventFieldDeclarationSyntax self) =>
        self.Declaration.Variables[index: 0].Property(self);

    /// <summary>
    ///     Converts the given indexer declaration into <see cref="DocIndexer" /> property.
    /// </summary>
    public static DocIndexer Indexer(this IndexerDeclarationSyntax self) =>
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
            Params = self.ParameterList.Params(),
        };

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

    private static string Accessors(this PropertyDeclarationSyntax self) =>
        self.AccessorList?.Accessors() ?? "{ get; }";

    private static string Accessors(this IndexerDeclarationSyntax self) =>
        self.AccessorList?.Accessors() ?? "{ get; }";

    private static string Accessors(this EventDeclarationSyntax self) =>
        self.AccessorList?.Accessors() ?? "{ add; remove; }";

    private static string Accessors(this AccessorListSyntax self) =>
        $"{{ {self.Accessors.Select(x => $"{x.Modifiers.ToString().Space()}{x.Keyword}; ").Separated("")}}}";
}