using System.Text;
using Summary.Extensions;
using static System.Environment;

namespace Summary.Markdown.Extensions;

/// <summary>
///     Extension methods for better rendering documentation into Markdown format.
/// </summary>
internal static class MarkdownRenderExtensions
{
    /// <summary>
    ///     Renders the specified documentation member into Markdown.
    /// </summary>
    public static Md Render(this DocMember self)
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

        if (member is DocMethod { Params.Length: not 0 } method)
        {
            if (method.Params.Any(x => x.Comment != DocComment.Empty))
            {
                sb.AppendLine($"{new string('#', level + 1)} Parameters");

                foreach (var param in method.Params)
                    if (param.Comment != DocComment.Empty)
                        sb.AppendLine($"- `{param.Name}`: {Render(param.Comment.Nodes)}");
            }
        }

        void Element(string name, Func<string, string>? map = null)
        {
            map ??= x => x;

            var x = member.Comment.Element(name);
            if (x is not null)
            {
                var lines = Render(x).Split(NewLine);

                foreach (var line in lines)
                    sb.AppendLine(line is not "" ? map(line) : "");

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
            .SelectWithNext(Render)
            .Separated(with: "");

    internal static string Render(this DocCommentNode? node, DocCommentNode? next = default) => node switch
    {
        null => "",

        DocCommentLiteral literal => literal.Value,

        DocCommentElement { Name: "code" } code =>
            $"```cs{NewLine}{Render(code.Nodes)}```",

        DocCommentElement element => element.Nodes
            .Trim()
            .SelectWithNext(Render)
            .Separated(with: ""),

        DocCommentLink link => $"[`{link.Value}`](./{link.Value}.md){LeadingTrivia(next)}",

        DocCommentParamRef @ref => $"`{@ref.Value}`{LeadingTrivia(next)}",

        _ => node.ToString()!,
    };

    private static string LeadingTrivia(DocCommentNode? node) => node switch
    {
        DocCommentLiteral literal => literal.LeadingTrivia,
        _ => "",
    };

    // TODO: Write an efficient implementation.
    private static IEnumerable<DocCommentNode> Trim(this IEnumerable<DocCommentNode> nodes) => nodes
        .SkipWhile(x => x.IsSpace() || x.IsNewLine())
        .Reverse()
        .SkipWhile(x => x.IsSpace() || x.IsNewLine())
        .Reverse();
}