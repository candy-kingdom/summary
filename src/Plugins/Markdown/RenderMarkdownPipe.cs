using Summary.Markdown.Extensions;
using Summary.Pipes;

namespace Summary.Markdown;

/// <summary>
///     A <see cref="IPipe{I,O}"/> that renders generated document into the sequence of Markdown files.
/// </summary>
public class RenderMarkdownPipe : IPipe<Doc, Md[]>
{
    public Task<Md[]> Run(Doc input) =>
        Task.FromResult(input.Members.Select(Render).ToArray());

    private static Md Render(DocMember member) =>
        member.Render();
}