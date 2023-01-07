namespace Doc.Net.Core;

/// <summary>
///     An documentation comment parsed from the source code.
/// </summary>
/// <param name="Nodes">The sequence of nodes this comment consists of (e.g. `summary`, `remarks`, etc.).</param>
public record DocComment(DocCommentNode[] Nodes);