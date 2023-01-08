using System.Text;
using Doc.Net.Core;
using Doc.Net.Core.Extensions;

namespace Net.Core.Markdown.Extensions;

/// <summary>
///     Extension methods for better rendering documentation into Markdown format.
/// </summary>
public static class MarkdownRenderExtensions
{
    /// <summary>
    ///     Renders the specified documentation member into Markdown.
    /// </summary>
    public static Markdown Render(this DocMember self)
    {
        var content = new StringBuilder();

        Render(self, content);

        return new($"{self.Name}.md", content.ToString());
    }

    private static void Render(DocMember member, StringBuilder sb, int level = 1)
    {
        sb.AppendLine($"{new string('#', level)} {member.Name}");

        Element("summary");
        Element("remarks", x => $"_{x}_");

        Declaration();

        Section("Example");

        if (member is DocType type)
        {
            Members<DocField>(type, "Fields");
            Members<DocProperty>(type, "Properties");
            Members<DocMethod>(type, "Methods");
        }

        void Element(string name, Func<string, string>? map = null)
        {
            map ??= x => x;

            var x = member.Comment.Element(name);
            if (x is not null)
            {
                sb.AppendLine(map(Render(x)));
                sb.AppendLine();
            }
        }

        void Declaration()
        {
            sb.AppendLine("```cs");
            sb.AppendLine(member.Declaration);
            sb.AppendLine("```");
            sb.AppendLine();
        }

        void Section(string name)
        {
            var x = member.Comment.Element(name.ToLower());
            if (x is not null)
            {
                sb.AppendLine($"{new string('#', level + 1)} {name}");
                sb.AppendLine(Render(x));
                sb.AppendLine();
            }
        }

        void Members<T>(DocType type, string name) where T : DocMember
        {
            var members = type.Members.OfType<T>();
            if (!members.Any())
                return;

            sb.AppendLine($"{new string('#', level + 1)} {name}");

            foreach (var x in members)
                Render(x, sb, level + 2);
        }
    }

    private static string Render(IEnumerable<DocCommentNode> nodes) =>
        nodes
            .Trim()
            .Select(Render)
            .Separated(with: "");

    private static string Render(DocCommentNode? node) => node switch
    {
        null => "",

        DocCommentLiteral literal => literal.Value,

        DocCommentElement { Name: "code" } code =>
            $"```cs{Environment.NewLine}{Render(code.Nodes)}```",

        DocCommentElement element => element.Nodes
            .Trim()
            .Select(Render)
            .Separated(with: ""),

        DocCommentLink link => $"[`{link.Value}`](./{link.Value}.md)",

        _ => node.ToString()!,
    };

    // TODO: Write an efficient implementation.
    private static IEnumerable<DocCommentNode> Trim(this IEnumerable<DocCommentNode> nodes) => nodes
        .SkipWhile(x => x.IsSpace() || x.IsNewLine())
        .Reverse()
        .SkipWhile(x => x.IsSpace() || x.IsNewLine())
        .Reverse();
}