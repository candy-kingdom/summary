using System.Text;
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
            .Select(x => Render(doc, x))
            .Concat(new [] { Index(doc) })
            .ToArray());

    private Md Render(Doc doc, DocMember member)
    {
        var text = new MdRenderer(doc, output).Member(member).Text();

        return new($"{member.FileName()}.md", text);
    }

    private Md Index(Doc doc)
    {
        return new("README.md", Content());

        string Content()
        {
            var text = new StringBuilder();
            var namespaces = doc
                .Index
                .Members
                .OfType<DocTypeDeclaration>()
                .GroupBy(x => x.Namespace)
                .ToDictionary(x => x.Key, x => x.ToList());

            foreach (var (ns, members) in namespaces)
            {
                text.AppendLine($"# {ns}");

                foreach (var member in members)
                    text.AppendLine($"- [**{member.FullyQualifiedName.Escape()}**]({member.FileName()}.md)");

                text.AppendLine();
            }

            return text.ToString();
        }
    }
}