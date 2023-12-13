using System.Text.RegularExpressions;
using Summary.Extensions;

namespace Summary.Caching;

internal partial class DocIndex
{
    public DocIndex(Doc doc) =>
        Members = doc.Members
            .Dfs(x => x is DocTypeDeclaration type ? type.Members : Enumerable.Empty<DocMember>())
            .ToArray();

    public DocMember[] Members { get; }

    public IEnumerable<DocTypeDeclaration> Types =>
        Members.OfType<DocTypeDeclaration>();

    public IEnumerable<DocCommentNode> Nodes(DocMember member) =>
        member.Comment.Nodes.Dfs(x => x is DocCommentElement e ? e.Nodes : Enumerable.Empty<DocCommentNode>());

    public IEnumerable<DocMember> SelfAndAncestors(DocMember member)
    {
        yield return member;

        foreach (var x in Ancestors(member))
            yield return x;
    }

    public IEnumerable<DocMember> Ancestors(DocMember member)
    {
        while (member.DeclaringType is not null)
        {
            var parent = Declaration(member.DeclaringType);
            if (parent is null)
                yield break;

            yield return parent;

            member = parent;
        }
    }

    public IEnumerable<DocMember> SelfAndBaseDeclarations(DocMember member)
    {
        yield return member;

        foreach (var x in BaseDeclarations(member))
            yield return x;
    }

    public IEnumerable<DocTypeDeclaration> BaseDeclarations(DocMember? member) => member switch
    {
        DocTypeDeclaration type => type.Base
            .Select(x => BaseDeclaration(x, member))
            .NonNulls()
            .Dfs(x => x.Base.Select(x => BaseDeclaration(x, member)).NonNulls()),

        null => Enumerable.Empty<DocTypeDeclaration>(),

        _ => BaseDeclarations(Declaration(member.DeclaringType)),
    };

    public DocTypeDeclaration? BaseDeclaration(DocType? @base, DocMember child)
    {
        if (@base is null)
            return null;

        if (Declaration(@base) is { } declaration)
            return declaration;

        // We omit base types since we're using this method for finding member that corresponds to base type.
        return ByCref(@base.FullName.AsCref(), child, includingBase: false) as DocTypeDeclaration;
    }

    public DocTypeDeclaration? Declaration(DocType? type) =>
        type is null
            ? null
            : Members.OfType<DocTypeDeclaration>().FirstOrDefault(x => x.FullyQualifiedName == type.FullyQualifiedName);

    public DocMember? ParentMember(DocCommentNode node) =>
        Members.FirstOrDefault(x => Nodes(x).Contains(node));

    public DocMember? ByCref(DocCommentLink link)
    {
        var scope = ParentMember(link);

        return scope is null ? null : ByCref(link.Value.Replace(" ", ""), scope);
    }

    public DocMember? ByCref(string cref, DocMember scope, bool includingBase = true)
    {
        var usings = new[] { scope.Namespace }
            .Concat(scope.Usings)
            .SelectMany(Namespaces)
            .Distinct()
            .OrderByDescending(x => x.Length)
            .ToArray();
        var ancestors = Among(SelfAndAncestors(scope)).ToList();
        var bases = includingBase ? Among(ancestors.SelectMany(BaseDeclarations)).ToList() : Enumerable.Empty<DocMember>();
        var other = Among(SuitableMembers()).ToList();

        return ancestors.Concat(bases).Concat(other).FirstOrDefault();

        IEnumerable<DocMember> Among(IEnumerable<DocMember> members) =>
            members
                .Dfs(x => x is DocTypeDeclaration type ? type.Members : Enumerable.Empty<DocMember>())
                .DistinctBy(x => x switch
                {
                    DocMethod m => m.FullyQualifiedSignature,

                    _ => x.FullyQualifiedName,
                })
                .Where(x => MatchesCref(x, cref));

        IEnumerable<DocMember> SuitableMembers() =>
            usings.SelectMany(x => Members.Where(y => y.Namespace == x));
    }

    private bool MatchesCref(DocMember member, string cref)
    {
        if (member.FullyQualifiedName.AsRawCref().EndsWith(cref.AsRawCref()))
            return true;

        if (member is DocMethod method)
        {
            if (method.FullyQualifiedSignature.EndsWith(cref))
                return true;

            // Make sure we're matching method with the link to a method.
            if (cref[^1] is not ')')
                return false;

            var i = cref.IndexOf('(');
            if (i is -1)
                return false;

            var name = cref[..i].AsRawCref();
            if (!method.FullyQualifiedName.AsRawCref().EndsWith(name))
                return false;

            var parameters = Params();
            if (!method.Params.Select(x => x.Type!.FullName.AsCref()).SequenceEqual(parameters, (a, b) => b.EndsWith(a)))
                return false;

            return true;

            string[] Params() =>
                ParamsRegex()
                    .Split(cref[(i + 1)..^1])
                    .Select(x => x.AsCref())
                    .ToArray();
        }

        return false;
    }

    [GeneratedRegex(@",(?![^\{]*\})")]
    private static partial Regex ParamsRegex();

    private static IEnumerable<string> Namespaces(string @using)
    {
        if (@using is "")
            yield break;

        yield return @using;

        var i = @using.LastIndexOf('.');
        if (i is -1)
            yield break;

        foreach (var x in Namespaces(@using[..i]))
            yield return x;
    }
}

public static class Extensions
{
    public static IEnumerable<T> Dfs<T>(this IEnumerable<T> self, Func<T, IEnumerable<T>> child)
    {
        return FromMany(self);

        IEnumerable<T> FromMany(IEnumerable<T> x) =>
            x.SelectMany(FromOne);

        IEnumerable<T> FromOne(T x)
        {
            yield return x;

            foreach (var y in FromMany(child(x)))
                yield return y;
        }
    }
}