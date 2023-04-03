﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Summary.Extensions;

namespace Summary.Roslyn.CSharp.Extensions;

public static class SyntaxNodeExtensions
{
    /// <summary>
    ///     A fully qualified name of
    /// </summary>
    /// <param name="self"></param>
    /// <returns></returns>
    public static string FullyQualifiedName(this SyntaxNode self)
    {
        var name = new List<string>();
        var node = (SyntaxNode?) self;

        while (node != null)
        {
            var x = node.Name();
            if (x is not null)
                name.Insert(index: 0, x);

            node = node.Parent;
        }

        return name.Separated(".");
    }

    public static string? Name(this SyntaxNode self) => self switch
    {
        BaseNamespaceDeclarationSyntax x => x.Name.ToString(),
        TypeDeclarationSyntax x => x.Identifier.Text,
        VariableDeclaratorSyntax x => x.Identifier.Text,
        PropertyDeclarationSyntax x => x.Identifier.Text,
        ParameterSyntax x => x.Identifier.Text,
        EventDeclarationSyntax x => x.Identifier.Text,
        MethodDeclarationSyntax x => x.Identifier.Text,
        DelegateDeclarationSyntax x => x.Identifier.Text,
        IndexerDeclarationSyntax => "this",

        BaseFieldDeclarationSyntax x => x.Declaration.Variables.First().Identifier.Text,

        _ => null,
    };
}