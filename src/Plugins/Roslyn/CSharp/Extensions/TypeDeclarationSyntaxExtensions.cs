using Microsoft.CodeAnalysis.CSharp.Syntax;
using Summary.Extensions;

namespace Summary.Roslyn.CSharp.Extensions;

/// <summary>
///     A set of extension methods that help converting different syntax nodes
///     into <see cref="DocTypeDeclaration" />.
/// </summary>
internal static class TypeDeclarationSyntaxExtensions
{
    /// <summary>
    ///     Converts the given type declaration into <see cref="DocTypeDeclaration" />.
    /// </summary>
    public static DocTypeDeclaration TypeDeclaration(this TypeDeclarationSyntax self) =>
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

    private static DocMember[] Members(this TypeDeclarationSyntax self) => self switch
    {
        RecordDeclarationSyntax record =>
            self
                .DescendantNodes()
                .SelectMany(x => x.Members())
                .Concat(record
                    .ParameterList?
                    .Parameters
                    .Select(x => x.Property()) ?? Enumerable.Empty<DocMember>())
                .NonNulls()
                .ToArray(),

        _ => self.DescendantNodes().SelectMany(x => x.Members()).NonNulls().ToArray(),
    };

    private static DocTypeParam[] TypeParams(this TypeDeclarationSyntax self) =>
        self.TypeParameterList.TypeParams();

    private static string Declaration(this TypeDeclarationSyntax self) => self switch
    {
        RecordDeclarationSyntax record =>
            $"{self.Attributes()}{self.Modifiers} {record.Keyword()} {self.Identifier}{self.TypeParameterList}{record.ParameterList} {self.BaseList}"
                .TrimEnd(),
        _ =>
            $"{self.Attributes()}{self.Modifiers} {self.Keyword} {self.Identifier}{self.TypeParameterList} {self.BaseList}"
                .TrimEnd(),
    };

    private static string Keyword(this RecordDeclarationSyntax self) =>
        self.ClassOrStructKeyword.Text is "" ? $"{self.Keyword}" : $"{self.Keyword} {self.ClassOrStructKeyword}";
}