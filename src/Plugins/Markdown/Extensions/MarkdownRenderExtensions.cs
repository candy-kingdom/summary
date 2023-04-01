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
        Name();
        Element("summary");
        Element("remarks", x => $"_{x}_");
        Declaration();
        Section("Example");

        if (member is DocTypeDeclaration type)
        {
            Parameters("Type Parameters", type.TypeParams.Select(x => (x.Name, x.Comment(type))));

            Members<DocField>(type, "Fields");

            if (type.Record)
                RecordProperties(type);
            else
                Members<DocProperty>(type, "Properties");

            Members<DocMethod>(type, "Methods");
        }

        if (member is DocMethod method)
            Method(method);

        void Name()
        {
            if (member is DocMethod method)
                sb.AppendLine($"{new string('#', level)} {member.Name}({Params(method)})");
            else
                sb.AppendLine($"{new string('#', level)} {member.Name}");

            string Params(DocMethod m) =>
                m.Params.Select(x => x.Type?.FullName ?? "").Separated(with:", ");
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

        void Members<T>(DocTypeDeclaration type, string name) where T : DocMember
        {
            var members = type.Members.OfType<T>();
            if (members.Any())
            {
                sb.AppendLine($"{new string('#', level + 1)} {name}");

                foreach (var x in members)
                    Render(x, sb, level + 2);
            }
        }

        // TODO: Refactor.
        void RecordProperties(DocTypeDeclaration record)
        {
            var props = type.Members.OfType<DocProperty>().ToList();
            if (props.Any())
            {
                sb.AppendLine($"{new string('#', level + 1)} Properties");

                var generated = props.Where(x => x.Generated).ToList();
                var simple = props.Where(x => !x.Generated).ToList();

                foreach (var x in generated)
                {
                    // Name.
                    sb.AppendLine($"{new string('#', level + 2)} {x.Name}");

                    // Summary.
                    var summary = record.Comment.Element("param", x.Name);
                    if (summary is not null)
                    {
                        var lines = Render(summary).Split(NewLine);

                        foreach (var line in lines)
                            sb.AppendLine(line);

                        sb.AppendLine();
                    }

                    // Declaration.
                    sb.AppendLine("```cs");
                    sb.AppendLine(x.Declaration);
                    sb.AppendLine("```");
                    sb.AppendLine();
                }

                foreach (var x in simple)
                    Render(x, sb, level + 2);
            }
        }

        void Method(DocMethod m)
        {
            Parameters("Parameters", m.Params.Select(x => (x.Name, x.Comment(m))));
            Parameters("Type Parameters", m.TypeParams.Select(x => (x.Name, x.Comment(m))));

            Section("Returns");
        }

        void Parameters(string section, IEnumerable<(string Name, DocCommentElement? Comment)> parameters)
        {
            if (parameters.All(x => x.Comment is null))
                return;

            sb.AppendLine($"{new string('#', level + 1)} {section}");

            foreach (var param in parameters)
                sb.AppendLine($"- `{param.Name}`: {Render(param.Comment)}");

            sb.AppendLine();
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

    // TODO: Write an efficient implementation.
    private static IEnumerable<DocCommentNode> Trim(this IEnumerable<DocCommentNode> nodes) => nodes
        .SkipWhile(x => x.IsSpace() || x.IsNewLine())
        .Reverse()
        .SkipWhile(x => x.IsSpace() || x.IsNewLine())
        .Reverse();
}