﻿using Microsoft.CodeAnalysis.CSharp.Syntax;

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
        new()
        {
            FullyQualifiedName = self.FullyQualifiedName(),
            Name = self.Name()!,
            Declaration =
                $"{self.Attributes()}{self.Modifiers} {self.ReturnType} {self.Identifier}{self.TypeParameterList}{self.ParameterList}",
            Access = self.Access(),
            Comment = self.Comment(),
            DeclaringType = self.DeclaringType(),
            Params = self.ParameterList.Params(),
            TypeParams = self.TypeParameterList.TypeParams(),
            Delegate = false,
        };

    /// <summary>
    ///     Converts the given delegate declaration into <see cref="DocMethod" />.
    /// </summary>
    public static DocMethod Delegate(this DelegateDeclarationSyntax self) => new()
    {
        FullyQualifiedName = self.FullyQualifiedName(),
        Name = self.Name()!,
        Declaration =
            $"{self.Attributes()}{self.Modifiers} {self.ReturnType} {self.Identifier}{self.TypeParameterList}{self.ParameterList}",
        Access = self.Access(),
        Comment = self.Comment(),
        Params = self.ParameterList.Params(),
        TypeParams = self.TypeParameterList.TypeParams(),
        DeclaringType = self.DeclaringType(),
        Delegate = true,
    };
}