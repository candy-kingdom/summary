using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Summary.Roslyn.CSharp.Extensions;

/// <summary>
///     A set of extension methods that help converting different syntax nodes
///     into <see cref="DocParam" /> or <see cref="DocTypeParam" />.
/// </summary>
internal static class ParamSyntaxExtensions
{
    /// <summary>
    ///     Converts the given parameter list into a sequence of <see cref="DocParam" />.
    /// </summary>
    public static DocParam[] Params(this BaseParameterListSyntax self) => self
        .Parameters
        .Select(x => new DocParam(x.Type?.Type(), x.Identifier.ValueText))
        .ToArray();

    /// <summary>
    ///     Converts the given parameter list into a sequence of <see cref="DocTypeParam" />.
    /// </summary>
    public static DocTypeParam[] TypeParams(this TypeParameterListSyntax? self) => self?
        .Parameters
        .Select(x => new DocTypeParam(x.Identifier.ValueText))
        .ToArray() ?? Array.Empty<DocTypeParam>();
}