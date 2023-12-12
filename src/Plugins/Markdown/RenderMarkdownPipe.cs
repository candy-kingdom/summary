using Summary.Pipes;

namespace Summary.Markdown;

/// <summary>
///     A <see cref="IPipe{I,O}"/> that renders generated document into the sequence of Markdown files.
/// </summary>
public class RenderMarkdownPipe(string output) : IPipe<Doc, Md[]>
{
    public Task<Md[]> Run(Doc doc) =>
        Task.FromResult(doc
            .Members
            .Concat(doc
                .Members
                .OfType<DocTypeDeclaration>()
                .SelectMany(x => x.AllMembers.OfType<DocTypeDeclaration>()))
            .Select(x => Render(doc, x)).ToArray());

    private Md Render(Doc doc, DocMember member)
    {
        var text = new MdRenderer(doc, output).Member(member).Text();

        return new($"{member.FileName()}.md", text);
    }
}