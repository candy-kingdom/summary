using Summary.Extensions;
using Summary.Pipes;

namespace Summary.Roslyn.CSharp;

/// <summary>
///     A <see cref="IPipe{I,O}"/> that inlines <c>&lt;inheritdoc/&gt;</c> tags.
/// </summary>
/// <remarks>
///     Under the hood, the process of inlining works as follows:
///     <br />
///         - each member in the <see cref="Doc"/> is analyzed
///         - if this member contains an <c>&lt;inheritdoc/&gt;</c> element, it's removed from the member comment
///         - then, the inherited documentation (either from the base type or from the specified cref) is added to the member comment.
/// </remarks>
public class InlineInheritDocPipe : IPipe<Doc, Doc>
{
    public Task<Doc> Run(Doc doc)
    {
        var inlined = doc.Members.Select(Inline).ToArray();

        return Task.FromResult(new Doc(inlined));

        DocMember Inline(DocMember member)
        {
            member = member with { Comment = InlineComment(member.Comment) };

            return member switch
            {
                // For type declarations we want both to inline the comment of the type
                // as well as the comments of the type members.
                DocTypeDeclaration type => type with { Members = type.Members.Select(Inline).ToArray() },
                _ => member,
            };

            // Order nodes so that <inheritdoc /> tags are always at the end.
            // This allows inlining them without overriding the user-defined nodes.
            DocComment InlineComment(DocComment comment) =>
                comment with { Nodes = comment.Nodes
                    .OrderBy(x => x is DocCommentInheritDoc)
                    .SelectMany(InlineNode)
                    .ToArray() };

            IEnumerable<DocCommentNode> InlineNode(DocCommentNode node) => node switch
            {
                DocCommentInheritDoc inherit => InlineInheritDoc(inherit),
                _ => new[] { node },
            };

            IEnumerable<DocCommentNode> InlineInheritDoc(DocCommentInheritDoc inherit)
            {
                var source = inherit.Cref is null or "" ? Base(member) : Cref(member, inherit.Cref);
                if (source == member)
                    return Enumerable.Empty<DocCommentNode>();
                if (source is null)
                    return Enumerable.Empty<DocCommentNode>();

                // We need to inline all comments in `source` to support complex chains
                // (e.g., `C` inherits `B` which inherits `A`).
                source = Inline(source);

                return source.Comment.Nodes;
            }
        }

        DocMember? Base(DocMember? x)
        {
            if (x is null)
                return null;

            if (x is DocTypeDeclaration declaration)
                return declaration.Base.Select(doc.Declaration).FirstOrDefault(x => x is not null);

            if (x is DocMethod method)
                return ByType(method, method.DeclaringType);

            if (x is DocProperty prop)
                return ByType(prop, prop.DeclaringType);

            if (x is DocIndexer indexer)
                return ByType(indexer, indexer.DeclaringType);

            return null;

            T? ByType<T>(T member, DocType? type) where T : DocMember
            {
                if (type is null)
                    return null;

                var declaration = doc.Declaration(type);
                if (declaration is null)
                    return null;

                var check = new Stack<DocType>();

                PushBase();

                while (check.Count > 0)
                {
                    type = check.Pop();
                    declaration = doc.Declaration(type);

                    if (declaration is null)
                        continue;

                    var x = declaration.Members.OfType<T>().FirstOrDefault(x => x.Name == member.Name);
                    if (x is not null)
                        return x;

                    PushBase();
                }

                return null;

                void PushBase()
                {
                    foreach (var @base in declaration.Base)
                        check.Push(@base);
                }
            }
        }

        // TODO: Should check cases where method tries to inherit type documentation?
        DocMember? Cref(DocMember x, string cref)
        {
            // Exclude all spaces from the `cref` for even formatting.
            cref = cref.Replace(" ", "");

            if (x is DocTypeDeclaration declaration)
                return declaration
                    .BaseDeclarations(doc)
                    .FirstOrDefault(x => x.FullyQualifiedName.EndsWith(cref));

            if (x is DocMethod method)
                return Ref(method.DeclaringType);

            if (x is DocField field)
                return Ref(field.DeclaringType);

            if (x is DocProperty prop)
                return Ref(prop.DeclaringType);

            if (x is DocIndexer indexer)
                return Ref(indexer.DeclaringType);

            if (x is DocDelegate @delegate)
                return Ref(@delegate.DeclaringType);

            return null;

            DocMember? Ref(DocType? type)
            {
                if (cref.Split('.') is [_, .., var name])
                {
                    var full = cref[..(cref.Length - name.Length - 1)];

                    return doc
                        .Declaration(type)?
                        .BaseDeclarationsAndSelf(doc)
                        .FirstOrDefault(x => x.FullyQualifiedName.EndsWith(full))?
                        .Members
                        .FirstOrDefault(x => x.MatchesCref(name));
                }
                else
                {
                    return doc.Declaration(type)?.Members.FirstOrDefault(x => x.MatchesCref(cref));
                }
            }
        }
    }
}