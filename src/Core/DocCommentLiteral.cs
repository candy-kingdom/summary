using Summary.Extensions;

namespace Summary;

/// <summary>
///     A <see cref="DocCommentNode"/> that represents a literal value (e.g. text, space, newline character, etc.).
/// </summary>
/// <param name="Value">The value of the literal.</param>
/// <param name="LeadingTrivia">
///     The leading trivia of the literal that is not included in the <paramref name="Value"/>(i.e. space characters, newlines).
/// </param>
/// <remarks>
///     Literals are simple tokens that are parsed as text.
/// </remarks>
public record DocCommentLiteral(string Value, string LeadingTrivia = "") : DocCommentNode
{
    /// <summary>
    ///     Constructs a new <see cref="DocCommentLiteral"/> from the given string.
    /// </summary>
    public static DocCommentLiteral New(string value) => value switch
    {
        " " => new DocCommentLiteral(value),
        _   => new DocCommentLiteral(value.TrimStart(), value.TakeWhile(x => x is ' ').Separated(with: "")),
    };
}