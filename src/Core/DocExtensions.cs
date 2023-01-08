using static System.Environment;

namespace Doc.Net.Core;

/// <summary>
///     Extension methods for different documentation model related types.
/// </summary>
public static class DocExtensions
{
    /// <summary>
    ///     Whether the given documentation comment node represents a space character.
    /// </summary>
    public static bool IsSpace(this DocCommentNode self) =>
        self is DocCommentLiteral { Value: " " };

    /// <summary>
    ///     Whether the given documentation comment node represents a space character.
    /// </summary>
    public static bool IsNewLine(this DocCommentNode self) =>
        self is DocCommentLiteral x && x.Value == NewLine;
}