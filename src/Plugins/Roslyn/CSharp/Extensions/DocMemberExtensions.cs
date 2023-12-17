using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Summary.Roslyn.CSharp.Extensions;

/// <summary>
///     A set of extension methods for <see cref="DocMember"/>.
/// </summary>
public static class DocMemberExtensions
{
    /// <summary>
    ///     Parses the comment from the specified member syntax and attaches it to this doc member.
    /// </summary>
    public static T WithComment<T>(this T self, MemberDeclarationSyntax syntax) where T : DocMember =>
        self with
        {
            Comment = syntax.Comment(self),
        };
}