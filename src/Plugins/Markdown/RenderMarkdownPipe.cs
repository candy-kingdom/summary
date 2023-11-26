using Summary.Extensions;
using Summary.Pipes;

namespace Summary.Markdown;

/// <summary>
///     A <see cref="IPipe{I,O}"/> that renders generated document into the sequence of Markdown files.
/// </summary>
public class RenderMarkdownPipe : IPipe<Doc, Md[]>
{
    public Task<Md[]> Run(Doc doc) =>
        Task.FromResult(doc
        .Members
        .Concat(doc
            .Members
            .OfType<DocTypeDeclaration>()
            .SelectMany(x => x.AllMembers.OfType<DocTypeDeclaration>()))
        .Select(Render).ToArray());

    private static Md Render(DocMember member)
    {
        var text = new MdRenderer().Member(member).Text();

        return new($"{Name(member)}.md", text);

        string Name(DocMember x) => x switch
        {
            DocTypeDeclaration { DeclaringType: null } type  => $"{x.Name}{TypeParams(type)}",
            DocTypeDeclaration { DeclaringType: not null } type => $"{type.DeclaringType!.FullName.AsCref()}.{x.Name}{TypeParams(type)}",

            _ => x.Name,
        };

        string TypeParams(DocTypeDeclaration x) => x.TypeParams.Length is 0 ? "" : $"{{{x.TypeParams.Select(x => x.Name).Separated(with: ",")}}}";
    }
}