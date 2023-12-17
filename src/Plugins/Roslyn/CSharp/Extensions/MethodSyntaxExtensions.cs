using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Summary.Roslyn.CSharp.Extensions;

/// <summary>
///     A set of extension methods that help converting different syntax nodes into <see cref="DocMethod" />.
/// </summary>
internal static class MethodSyntaxExtensions
{
    /// <summary>
    ///     Converts the given method declaration into <see cref="DocMethod" />.
    /// </summary>
    public static DocMethod Method(this MethodDeclarationSyntax self) =>
        new DocMethod
        {
            Namespace = self.Namespace() ?? "",
            FullyQualifiedName = self.FullyQualifiedName(),
            Name = self.Name()!,
            Declaration =
                $"{self.AttributesDeclaration()}{self.Modifiers} {self.ReturnType} {self.Identifier}{self.TypeParameterList}{self.ParameterList}",
            Access = self.Access(),
            DeclaringType = self.DeclaringType(),
            Deprecation = self.AttributeLists.Deprecation(),
            Location = self.Identifier.Location(),
            Params = self.ParameterList.Params(),
            TypeParams = self.TypeParameterList.TypeParams(),
            Usings = self.Usings(),
            Delegate = false,
        }.WithComment(self);

    /// <summary>
    ///     Converts the given delegate declaration into <see cref="DocMethod" />.
    /// </summary>
    public static DocMethod Delegate(this DelegateDeclarationSyntax self) =>
        new DocMethod
        {
            Namespace = self.Namespace() ?? "",
            FullyQualifiedName = self.FullyQualifiedName(),
            Name = self.Name()!,
            Declaration =
                $"{self.AttributesDeclaration()}{self.Modifiers} {self.ReturnType} {self.Identifier}{self.TypeParameterList}{self.ParameterList}",
            Access = self.Access(),
            Params = self.ParameterList.Params(),
            TypeParams = self.TypeParameterList.TypeParams(),
            DeclaringType = self.DeclaringType(),
            Deprecation = self.AttributeLists.Deprecation(),
            Location = self.Identifier.Location(),
            Usings = self.Usings(),
            Delegate = true,
        }.WithComment(self);
}