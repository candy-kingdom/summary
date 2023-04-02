using Summary.Extensions;
using static System.Environment;

namespace Summary.Markdown.Extensions;

/// <summary>
///     Extension methods for better rendering documentation into Markdown format.
/// </summary>
internal static class MarkdownRenderExtensions
{
    private static string Render(IEnumerable<DocCommentNode> nodes) =>
        nodes
            .Trim()
            .SelectWithNext(Render)
            .Separated(with: "");

    internal static string Render(this DocCommentNode? node, DocCommentNode? next = default) => node switch
    {
        null => "",

        DocCommentLiteral literal => literal.Value,

        DocCommentElement { Name: "c" } code =>
            $"`{Render(code.Nodes)}`{LeadingTrivia(next)}",
        DocCommentElement { Name: "i" or "em" } code =>
            $"_{Render(code.Nodes)}_{LeadingTrivia(next)}",
        DocCommentElement { Name: "b" or "strong" } code =>
            $"**{Render(code.Nodes)}**{LeadingTrivia(next)}",
        DocCommentElement { Name: "strike" } code =>
            $"~~{Render(code.Nodes)}~~{LeadingTrivia(next)}",
        DocCommentElement { Name: "code" } code =>
            $"```cs{NewLine}{Render(code.Nodes)}```",

        DocCommentLink link => $"[`{link.Value}`](./{link.Value}.md){LeadingTrivia(next)}",

        DocCommentParamRef @ref => $"`{@ref.Value}`{LeadingTrivia(next)}",

        DocCommentElement element => element.Nodes
            .Trim()
            .SelectWithNext(Render)
            .Separated(with: ""),

        _ => node.ToString()!,
    };

    private static string LeadingTrivia(DocCommentNode? node) => node switch
    {
        DocCommentLiteral literal => literal.LeadingTrivia,
        _ => "",
    };

    internal static string Render(this DocMethod self) =>
        $"{self.Name}{self.RenderTypeParams()}{self.RenderParams()}";

    private static string RenderParams(this DocMethod self) =>
        $"({self.Params.Select(x => x.Type?.FullName ?? "").Separated(with: ", ")})";

    private static string RenderTypeParams(this DocMethod self) =>
        self.TypeParams.Length > 0 ? $"<{self.TypeParams.Select(x => x.Name).Separated(with: ", ")}>" : "";

    // TODO: Write an efficient implementation.
    private static IEnumerable<DocCommentNode> Trim(this IEnumerable<DocCommentNode> nodes) => nodes
        .SkipWhile(x => x.IsSpace() || x.IsNewLine())
        .Reverse()
        .SkipWhile(x => x.IsSpace() || x.IsNewLine())
        .Reverse();
}