using System.Text.RegularExpressions;
using Summary.Extensions;

namespace Summary.Caching;

/// <summary>
///     A fast-access cache of different members inside a particular <see cref="Doc"/>.
/// </summary>
internal partial class DocIndex
{
    private class MembersCache
    {
        public readonly Dictionary<DocCommentLink, DocMember?> ByLink = new();
        public readonly Dictionary<string, Dictionary<DocMember, DocMember?>> ByCref = new();
        public readonly Dictionary<DocCommentNode, DocMember?> ByCommentNode = new();
    }

    private class AncestorsCache
    {
        public readonly Dictionary<DocMember, List<DocMember>> ByMember = new();
    }

    private readonly MembersCache _members = new();
    private readonly AncestorsCache _ancestors = new();

    /// <summary>
    ///     Builds new index form the specified document.
    /// </summary>
    public DocIndex(Doc doc) =>
        Members = doc.Members
            .Dfs(x => x is DocTypeDeclaration type ? type.Members : Enumerable.Empty<DocMember>())
            .ToArray();

    /// <summary>
    ///     All members (including nested ones) of the document.
    /// </summary>
    public DocMember[] Members { get; }

    /// <summary>
    ///     All types (including nested ones) of the document.
    /// </summary>
    public IEnumerable<DocTypeDeclaration> Types =>
        Members.OfType<DocTypeDeclaration>();

    /// <summary>
    ///     The type declaration that corresponds to the given type.
    /// </summary>
    /// <remarks>
    ///     This method might be suitable when, for example, you have a parameter type and
    ///     you want to find type declaration that suits this parameter type best.
    /// </remarks>
    public DocTypeDeclaration? Declaration(DocType? type) =>
        type is null
            ? null
            : Members.OfType<DocTypeDeclaration>().FirstOrDefault(x => x.FullyQualifiedName == type.FullyQualifiedName);

    /// <summary>
    ///     All comment nodes (including nested ones) of the given member.
    /// </summary>
    public IEnumerable<DocCommentNode> Nodes(DocMember member) =>
        member.Comment.Nodes.Dfs(x => x is DocCommentElement e ? e.Nodes : Enumerable.Empty<DocCommentNode>());

    /// <summary>
    ///     The given member + all of its ancestors (declaring types).
    /// </summary>
    public IEnumerable<DocMember> SelfAndAncestors(DocMember member)
    {
        yield return member;

        foreach (var x in Ancestors(member))
            yield return x;
    }

    /// <summary>
    ///     All ancestors (declaring types) of the given member.
    /// </summary>
    public IEnumerable<DocMember> Ancestors(DocMember member)
    {
        return _ancestors.ByMember.TryGetValue(member, out var ancestors)
            ? ancestors
            : _ancestors.ByMember[member] = Recursive().ToList();

        IEnumerable<DocMember> Recursive()
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

    }

    /// <summary>
    ///     The given member + all of its base type declarations.
    /// </summary>
    public IEnumerable<DocMember> SelfAndBaseDeclarations(DocMember member)
    {
        yield return member;

        foreach (var x in BaseDeclarations(member))
            yield return x;
    }

    /// <summary>
    ///     The base type declarations (including bases of bases if possible) of the given member.
    /// </summary>
    public IEnumerable<DocTypeDeclaration> BaseDeclarations(DocMember? member) => member switch
    {
        DocTypeDeclaration type => type.Base
            .Select(x => BaseDeclaration(x, member))
            .NonNulls()
            .Dfs(x => x.Base.Select(x => BaseDeclaration(x, member)).NonNulls()),

        null => Enumerable.Empty<DocTypeDeclaration>(),

        _ => BaseDeclarations(Declaration(member.DeclaringType)),
    };

    /// <summary>
    ///     The base type declaration of the given type.
    ///     The <paramref name="child"/> is a member that inherits from the <paramref name="@base"/>.
    /// </summary>
    public DocTypeDeclaration? BaseDeclaration(DocType? @base, DocMember child)
    {
        if (@base is null)
            return null;

        if (Declaration(@base) is { } declaration)
            return declaration;

        // We omit base types since we're using this method for finding member that corresponds to base type.
        return ByCref(@base.FullName.AsCref(), child, includingBase: false) as DocTypeDeclaration;
    }

    /// <summary>
    ///     The <see cref="DocMember"/> the comment node is defined for.
    /// </summary>
    // TODO: We can include the member inside `DocCommentNode` at the generation time (@j.light).
    public DocMember? Member(DocCommentNode node) =>
        _members.ByCommentNode.TryGetValue(node, out var member)
            ? member
            : _members.ByCommentNode[node] = Members.FirstOrDefault(x => Nodes(x).Contains(node));

    /// <summary>
    ///     Searches a <see cref="DocMember"/> by the provided link.
    /// </summary>
    public DocMember? ByCref(DocCommentLink link)
    {
        if (_members.ByLink.TryGetValue(link, out var member))
            return member;

        var scope = Member(link);

        member = scope is null ? null : ByCref(link.Value.Replace(" ", ""), scope);

        return _members.ByLink[link] = member;
    }

    /// <summary>
    ///     Searches a <see cref="DocMember"/> by the provided <paramref name="cref"/> value.
    ///     The <paramref name="scope"/> member represents the inner-most scope to start the search from.
    ///     Specify <see cref="includingBase"/> if you want to search among lists of base types.
    /// </summary>
    public DocMember? ByCref(string cref, DocMember scope, bool includingBase = true)
    {
        if (!_members.ByCref.TryGetValue(cref, out var byScope))
            _members.ByCref[cref] = byScope = new();

        if (byScope.TryGetValue(scope, out var member))
            return member;

        var usings = new[] { scope.Namespace }
            .Concat(scope.Usings)
            .SelectMany(SelfAndAncestorNamespaces)
            .Distinct()
            .OrderByDescending(x => x.Length)
            .ToArray();
        var ancestors = Among(SelfAndAncestors(scope)).ToList();
        var bases = includingBase ? Among(ancestors.SelectMany(BaseDeclarations)).ToList() : Enumerable.Empty<DocMember>();
        var other = Among(SuitableMembers()).ToList();

        return byScope[scope] = ancestors.Concat(bases).Concat(other).FirstOrDefault();

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

    /// <summary>
    ///     Whether the given member matches the specified <c>cref</c>.
    /// </summary>
    private bool MatchesCref(DocMember member, string cref)
    {
        if (member.FullyQualifiedName.AsRawCref().EndsWith(cref.AsRawCref()))
        {
            // We don't want for `*Something` to match `Something`.
            return cref.AsRawCref().EndsWith(member.Name.AsRawCref());
        }

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

    /// <summary>
    ///     Given the namespace, returns this namespace + all ancestor namespaces.
    ///     <br />
    ///     For example, for <c>"Summary.Part.Two"</c> this method will return
    ///     <c>["Summary.Part.Two", "Summary.Part", "Summary"]</c>.
    /// </summary>
    private static IEnumerable<string> SelfAndAncestorNamespaces(string ns)
    {
        yield return ns;

        while (true)
        {
            var i = ns.LastIndexOf('.');
            if (i is -1)
                break;

            yield return ns = ns[..i];
        }
    }
}