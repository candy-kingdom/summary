using Summary.Extensions;
using Summary.Pipes;

namespace Summary.Markdown;

/// <summary>
///     A <see cref="IPipe{I,O}"/> that renders generated document into the sequence of Markdown files.
/// </summary>
public class RenderMarkdownPipe : IPipe<Doc, Md[]>
{
    public Task<Md[]> Run(Doc input) =>
        Task.FromResult(input.Members.Select(Render).ToArray());

    private static Md Render(DocMember member)
    {
        var text = new MdRenderer().Member(member).Text();

        return new($"{Name(member)}.md", text);

        string Name(DocMember x) => x switch
        {
            DocTypeDeclaration type => $"{x.Name}{TypeParams(type)}",

            _ => x.Name,
        };

        string TypeParams(DocTypeDeclaration x) => x.TypeParams.Length is 0 ? "" : $"{{{x.TypeParams.Select(x => x.Name).Separated(with: ",")}}}";
    }
}