using Summary.Markdown.Extensions;
using Summary.Pipes;

namespace Summary.Markdown;

/// <summary>
///     A <see cref="IPipe{I,O}"/> that renders generated document into the sequence of Markdown files.
/// </summary>
public class MarkdownRenderPipe : IPipe<Doc, Markdown[]>
{
    public Task<Markdown[]> Run(Doc input) =>
        Task.FromResult(input.Members.Select(Render).ToArray());

    private static Markdown Render(DocMember member) =>
        member.Render();
}