using Summary.Extensions;
using static System.Environment;

namespace Summary.Markdown;

/// <summary>
///     Extension methods for better rendering documentation into Markdown format.
/// </summary>
internal static class MarkdownRenderExtensions
{
    /// <summary>
    ///     The source file name for this member.
    /// </summary>
    internal static string FileName(this DocMember self) =>
        self.FullyQualifiedName.AsCref();

    /// <summary>
    ///     Converts the specified comment node into a Markdown string.
    /// </summary>
    /// <remarks>
    ///     The next comment node is used to add a trailing trivia to the rendered node.
    /// </remarks>
    internal static string Render(this DocCommentNode? node, Doc doc, DocCommentNode? next = default) => node switch
    {
        null => "",

        DocCommentLiteral literal => literal.Value,

        DocCommentElement { Name: "c" } code =>
            $"`{code.Nodes.Render(doc)}`{next.LeadingTrivia()}",
        DocCommentElement { Name: "i" or "em" } code =>
            $"_{code.Nodes.Render(doc)}_{next.LeadingTrivia()}",
        DocCommentElement { Name: "b" or "strong" } code =>
            $"**{code.Nodes.Render(doc)}**{next.LeadingTrivia()}",
        DocCommentElement { Name: "strike" } code =>
            $"~~{code.Nodes.Render(doc)}~~{next.LeadingTrivia()}",
        DocCommentElement { Name: "code" } code =>
            $"```cs{NewLine}{code.Nodes.Render(doc)}```",

        DocCommentLink link => $"{link.Render(doc)}{next.LeadingTrivia()}",

        DocCommentParamRef @ref => $"`{@ref.Value}`{next.LeadingTrivia()}",

        DocCommentElement element => element.Nodes
            .Trim()
            .SelectWithNext((x, n) => Render(x, doc, n))
            .Separated(""),

        _ => node.ToString()!,
    };

    private static string Render(this IEnumerable<DocCommentNode> nodes, Doc doc) =>
        nodes
            .Trim()
            .SelectWithNext((x, n) => Render(x, doc, n))
            .Separated("");

    private static string LeadingTrivia(this DocCommentNode? node) => node switch
    {
        DocCommentLiteral literal => literal.LeadingTrivia,
        _ => "",
    };

    // TODO: Consider writing a more efficient implementation.
    // This method removes all space and newline characters from the beginning and the end of the sequence.
    private static IEnumerable<DocCommentNode> Trim(this IEnumerable<DocCommentNode> nodes) => nodes
        .SkipWhile(x => x.IsSpace() || x.IsNewLine())
        .Reverse()
        .SkipWhile(x => x.IsSpace() || x.IsNewLine())
        .Reverse();

    private static string Render(this DocCommentLink self, Doc doc)
    {
        var cref = doc.Cref(self);
        if (cref is null)
            return $"<u>`{self.Value}`</u>";

        return $"[`{self.Value}`](./{FileName(cref)}.md{SectionName(cref)})";

        string FileName(DocMember x) => x switch
        {
            DocMethod method =>
                $"{doc.Declaration(method.DeclaringType)!.FileName()}",

            _ => x.FileName(),
        };

        string SectionName(DocMember x) => x switch
        {
            DocMethod method => $"#{method.Signature}",

            _ => "",
        };
    }
}