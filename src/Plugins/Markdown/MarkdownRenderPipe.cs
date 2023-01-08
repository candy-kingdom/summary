using Doc.Net.Core;
using Doc.Net.Core.Pipes;
using Doc.Net.Markdown.Extensions;

namespace Doc.Net.Markdown;

/// <summary>
///     A <see cref="IPipe{I,O}"/> that renders generated document into the sequence of Markdown files.
/// </summary>
public class MarkdownRenderPipe : IPipe<Document, Markdown[]>
{
    public Task<Markdown[]> Run(Document input) =>
        Task.FromResult(input.Members.Select(Render).ToArray());

    private static Markdown Render(DocMember member) =>
        member.Render();
}