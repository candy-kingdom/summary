using System.Text;
using Summary.Extensions;
using Summary.Markdown.Extensions;
using static System.Environment;

namespace Summary.Markdown;

public class MdRenderer
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

    private readonly StringBuilder _sb = new();

    private int _level = 1;

    public string Text() =>
        _sb.ToString();

    public MdRenderer Member(DocMember member) => Member(parent: null, member);

    public MdRenderer Member(DocTypeDeclaration? parent, DocMember member) => member switch
    {
        DocTypeDeclaration type =>
            MemberHeader(type).TypeDeclaration(type),
        DocMethod method =>
            MemberHeader(method).Method(method),
        DocProperty { Generated: true } generated =>
            GeneratedProperty(parent!, generated),
        DocIndexer indexer =>
            MemberHeader(indexer).Indexer(indexer),
        _ =>
            MemberHeader(member),
    };

    private MdRenderer TypeDeclaration(DocTypeDeclaration type)
    {
        TypeParamsSection(type);

        MembersSection<DocProperty>("Events", type, x => x.Event);
        MembersSection<DocField>("Fields", type);
        MembersSection<DocProperty>("Properties", type, x => !x.Event);
        MembersSection<DocIndexer>("Indexers", type);
        MembersSection<DocMethod>("Methods", type);

        return this;
    }

    private MdRenderer Method(DocMethod method) => this
        .ParamsSection(method)
        .TypeParamsSection(method)
        .ReturnsSection(method);

    private MdRenderer Indexer(DocIndexer indexer) => this
        .ParamsSection(indexer)
        .ReturnsSection(indexer);

    private MdRenderer MemberHeader(DocMember member) => this
        .Name(member)
        .Element(member.Comment.Element("summary"))
        .Element(member.Comment.Element("remarks"), x => $"_{x}_")
        .Declaration(member)
        .ElementSection("Example", member.Comment.Element("example"));

    private MdRenderer GeneratedProperty(DocTypeDeclaration parent, DocMember prop) => this
        .Name(prop)
        .Element(parent.Comment.Param(prop.Name))
        .Declaration(prop);

    private MdRenderer Name(DocMember member) => member switch
    {
        DocMethod x =>
            Line($"{new string('#', _level)} {x.Render()}"),
        _ =>
            Line($"{new string('#', _level)} {member.Name}"),
    };

    private MdRenderer ElementSection(string name, DocCommentElement? element, Func<string, string>? map = null) =>
        element is null ? this : Line($"{new string('#', _level + 1)} {name}").Element(element, map);

    private MdRenderer Declaration(DocMember member) => this
        .Line("```cs")
        .Line(member.Declaration)
        .Line("```")
        .Line();

    private MdRenderer ParamsSection(DocMethod method) =>
        ParamsSection("Parameters", method.Params.Select(x => (x.Name, x.Comment(method))));

    private MdRenderer ParamsSection(DocIndexer method) =>
        ParamsSection("Parameters", method.Params.Select(x => (x.Name, x.Comment(method))));

    private MdRenderer TypeParamsSection(DocMethod method) =>
        ParamsSection("Type Parameters", method.TypeParams.Select(x => (x.Name, x.Comment(method))));

    private MdRenderer TypeParamsSection(DocTypeDeclaration type) =>
        ParamsSection("Type Parameters", type.TypeParams.Select(x => (x.Name, x.Comment(type))));

    private MdRenderer ParamsSection(string section, IEnumerable<(string Name, DocCommentElement? Comment)> parameters)
    {
        if (parameters.All(x => x.Comment is null))
            return this;

        Section(section);

        foreach (var param in parameters)
            Line($"- `{param.Name}`: {param.Comment.Render()}");

        return Line();
    }

    public MdRenderer ReturnsSection(DocMethod method) =>
        ElementSection("Returns", method.Comment.Element("returns"));

    public MdRenderer ReturnsSection(DocIndexer method) =>
        ElementSection("Returns", method.Comment.Element("returns"));

    private MdRenderer MembersSection<T>(string section, DocTypeDeclaration type) where T : DocMember =>
        MembersSection<T>(section, type, _ => true);

    private MdRenderer MembersSection<T>(string section, DocTypeDeclaration type, Func<T, bool> p) where T : DocMember =>
        MembersSection(section, type, type.Members.OfType<T>().Where(p));

    private MdRenderer MembersSection<T>(string section, DocTypeDeclaration type, IEnumerable<T> members) where T : DocMember =>
        MembersSection(section, type, members, Member);

    private MdRenderer MembersSection<T>(string section, DocTypeDeclaration type, IEnumerable<T> members, Func<DocTypeDeclaration, T, MdRenderer> render) where T : DocMember
    {
        if (members.Any())
        {
            Section(section);

            using var _ = new Scope(this);

            foreach (var x in members)
                render(type, x);
        }

        return this;
    }

    private MdRenderer Element(DocCommentElement? element, Func<string, string>? map = null)
    {
        if (element is null)
            return this;

        var lines =
            element
                .Render()
                .Split(NewLine)
                .Select(x => x is "" ? x : map?.Invoke(x) ?? x);

        foreach (var line in lines)
            Line(line);

        return Line();
    }

    private MdRenderer Section(string name) =>
        Line($"{new string('#', _level + 1)} {name}");

    private MdRenderer Line(string s = "", bool when = true) =>
        With(when ? _sb.AppendLine(s) : _sb);

    private MdRenderer With<T>(T _) =>
        this;
}
