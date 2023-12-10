using System.Text;
using Summary.Extensions;
using static System.Environment;

namespace Summary.Markdown;

/// <summary>
///     A <see cref="Doc" /> to Markdown renderer.
/// </summary>
/// <remarks>
///     This type is responsible for converting different <see cref="DocMember" /> instances into text representation.
///     <br />
///     It's used only as intermediate helper and should not be exposed to the outside world.
/// </remarks>
internal class MdRenderer
{
    private class Scope : IDisposable
    {
        private readonly MdRenderer _renderer;

        public Scope(MdRenderer renderer)
        {
            _renderer = renderer;
            _renderer._level += 2;
        }

        public void Dispose() =>
            _renderer._level -= 2;
    }

    private readonly StringBuilder _builder = new();
    private readonly string _output;

    private int _level = 1;

    public MdRenderer(string output) =>
        _output = Path.GetFullPath(output);

    /// <summary>
    ///     Converts the rendered Markdown into a string.
    /// </summary>
    public string Text() =>
        _builder.ToString();

    /// <summary>
    ///     Renders the specified documentation member into Markdown format.
    /// </summary>
    public MdRenderer Member(DocMember member) => Member(parent: null, member);

    private MdRenderer Member(DocTypeDeclaration? parent, DocMember member) => member switch
    {
        DocTypeDeclaration type => TypeDeclaration(type),
        DocMethod method => Method(method),
        DocProperty property => Property(parent!, property),
        _ => Header(member),
    };

    private MdRenderer TypeDeclaration(DocTypeDeclaration type) => this
        .Header(type)
        .TypeParams(type)
        .Members<DocMethod>("Delegates", type, x => x.Delegate)
        .Members<DocProperty>("Events", type, x => x.Event)
        .Members<DocField>("Fields", type)
        .Members<DocProperty>("Properties", type, x => !x.Event && x is not DocIndexer)
        .Members<DocIndexer>("Indexers", type)
        .Members<DocMethod>("Methods", type, x => !x.Delegate);

    private MdRenderer Method(DocMethod method) => this
        .Header(method)
        .TypeParams(method)
        .Params(method)
        .Returns(method.Comment)
        .Exceptions(method.Comment);

    private MdRenderer Property(DocTypeDeclaration parent, DocProperty property)
    {
        if (property.Generated)
            return this
                .Name(property)
                .Declaration(property)
                .Element(parent.Comment.Param(property.Name))
                .Exceptions(property.Comment);

        if (property is DocIndexer indexer)
            return Indexer(indexer);

        return Header(property).Exceptions(property.Comment);
    }

    private MdRenderer Indexer(DocIndexer indexer) => this
        .Header(indexer)
        .Params(indexer)
        .Returns(indexer.Comment)
        .Exceptions(indexer.Comment);

    private MdRenderer Header(DocMember member) => this
        .Name(member)
        .Deprecation(member.Deprecation)
        .Declaration(member)
        .Element(member.Comment.Element("summary"))
        .Element(member.Comment.Element("remarks"), x => $"_{x}_")
        .Elements("Example", member.Comment.Element("example"));

    private MdRenderer Name(DocMember member)
    {
        return member switch
        {
            DocMethod method =>
                Line($"{new string(c: '#', _level)} " +
                     Link(
                         $"{method.Name.Surround("~~", "~~", when: method.Deprecated)}" +
                         $"{method.TypeParams.Select(x => x.Name).Separated(", ").Surround("<", ">")}" +
                         $"({method.Params.Select(x => x.Type?.FullName).NonNulls().Separated(", ")})")),
            DocIndexer indexer =>
                Line($"{new string(c: '#', _level)} " +
                     Link($"this[{indexer.Params.Select(x => x.Type?.Name).NonNulls().Separated(", ")}]")),
            DocTypeDeclaration type when _level is 1 =>
                Line($"{new string(c: '#', _level)} " +
                     Link($"{type.FullyQualifiedName.Surround("~~", "~~", when: type.Deprecated)}" +
                          $"{type.TypeParams.Select(x => x.Name).Separated(with: ", ").Surround("<", ">")}")),
            _ =>
                Line($"{new string(c: '#', _level)} " +
                     Link($"{member.Name.Surround("~~", "~~", when: member.Deprecated)}")),
        };

        string Link(string text)
        {
            if (member.Location is not null)
            {
                var from = new Uri(_output);
                var to = new Uri(member.Location.Path);

                return $"[{text}]({from.MakeRelativeUri(to)}#L{member.Location.Start.Line + 1})";
            }

            return text;
        }
    }

    private MdRenderer Deprecation(DocDeprecation? deprecation)
    {
        if (!string.IsNullOrWhiteSpace(deprecation?.Message))
        {
            // We currently render the deprecation message as an alert: https://github.com/orgs/community/discussions/16925.
            // > Alerts are an extension of Markdown used to emphasize critical information. On GitHub, they
            // > are displayed with distinctive colors and icons to indicate the importance of the content.
            return this
                .Line($"> [!WARNING]")
                .Line($"> {deprecation.Message}")
                .Line();
        }

        return this;
    }

    private MdRenderer Declaration(DocMember member) => this
        .Line("```cs")
        .Line(member.Declaration)
        .Line("```")
        .Line();

    private MdRenderer TypeParams(DocMethod method) =>
        Params("Type Parameters", method.TypeParams.Select(x => (x.Name, x.Comment(method))));

    private MdRenderer TypeParams(DocTypeDeclaration type) =>
        Params("Type Parameters", type.TypeParams.Select(x => (x.Name, x.Comment(type))));

    private MdRenderer Params(DocMethod method) =>
        Params("Parameters", method.Params.Select(x => (x.Name, x.Comment(method))));

    private MdRenderer Params(DocIndexer method) =>
        Params("Parameters", method.Params.Select(x => (x.Name, x.Comment(method))));

    private MdRenderer Params(string section, IEnumerable<(string Name, DocCommentElement? Comment)> parameters) =>
        Params(section, parameters.Where(x => x.Comment is not null).ToList()!);

    private MdRenderer Params(string section, ICollection<(string Name, DocCommentElement Comment)> parameters) =>
        Section(section, parameters, x => Line($"- `{x.Name}`: {x.Comment.Render()}")).Line(when: parameters.Any());

    private MdRenderer Members<T>(string section, DocTypeDeclaration type) where T : DocMember =>
        Members<T>(section, type, _ => true);

    private MdRenderer Members<T>(string section, DocTypeDeclaration type, Func<T, bool> p) where T : DocMember =>
        Members(section, type, type.Members.OfType<T>().Where(p));

    private MdRenderer Members<T>(string section, DocTypeDeclaration type, IEnumerable<T> members) where T : DocMember =>
        Section(section, members, x => Member(type, x));

    private MdRenderer Returns(DocComment comment) =>
        Elements("Returns", comment.Element("returns"));

    private MdRenderer Exceptions(DocComment comment) =>
        Params("Exceptions", comment.Elements("exception").Select(x => (x.Attribute("cref")?.Value ?? " ", x))!);

    private MdRenderer Elements(string section, DocCommentElement? element, Func<string, string>? map = null) =>
        element is null ? this : Section(section).Element(element, map);

    private MdRenderer Element(DocCommentElement? element, Func<string, string>? map = null)
    {
        if (element is null)
            return this;

        var lines = element
            .Render()
            .Split(NewLine)
            .Select(x => x is "" ? x : map?.Invoke(x) ?? x);

        foreach (var line in lines)
            Line(line);

        return Line();
    }

    private MdRenderer Section(string name)
    {
        _builder.Append('#', _level + 1).Append(' ').AppendLine(name);
        return this;
    }

    private MdRenderer Section<T>(string name, IEnumerable<T> items, Action<T> render)
    {
        var scope = null as IDisposable;

        try
        {
            foreach (var item in items)
            {
                scope ??= Section(name).Scoped();

                render(item);
            }
        }
        finally
        {
            scope?.Dispose();
        }

        return this;
    }

    private MdRenderer Line(string text = "", bool when = true)
    {
        if (when)
            _builder.AppendLine(text);

        return this;
    }

    private Scope Scoped() =>
        new(this);
}