using Microsoft.CodeAnalysis.CSharp.Syntax;
using Summary.Extensions;
using Summary.Pipes;

namespace Summary.Roslyn.CSharp;

public class InlineInheritDocPipe : IPipe<Doc[], Doc>
{
    // TODO: [x] Base types (1 level)
    // TODO: [x] Base interfaces
    // TODO: [x] Base methods
    // TODO: [x] Base crefs
    // TODO: [x] Base properties
    // TODO: [x] Properties in records
    // TODO: [x] Base types (n levels)
    // TODO: [x] Inheriting inherited docs?
    // TODO: [x] Crefs: base types (types)
    // TODO: [x] Base members (n levels)
    // TODO: [x] Crefs: namespaces and full paths
    // TODO: [x] Base events
    // TODO: [x] Base indexers
    // TODO: [ ] Complex crefs with type parameters and overloadings (out, ref, in)
    // TODO: [ ] Complex merging rules
    public Task<Doc> Run(Doc[] input)
    {
        var members = input.SelectMany(x => x.Members).ToArray();
        var inlined = members.Select(Inline).ToArray();

        return Task.FromResult(new Doc(inlined));

        DocMember Inline(DocMember member)
        {
            return member switch
            {
                DocTypeDeclaration type => type with
                {
                    Members = type.Members.Select(Inline).ToArray(),
                    Comment = InlineComment(member.Comment),
                },
                _ => member with { Comment = InlineComment(member.Comment) },
            };

            DocComment InlineComment(DocComment comment) =>
                new(comment.Nodes.SelectMany(InlineNode).ToArray());

            IEnumerable<DocCommentNode> InlineNode(DocCommentNode node)
            {
                if (node is DocCommentInheritDoc inheritDoc)
                {
                    foreach (var x in Inlined(inheritDoc))
                        yield return x;
                }
                else
                {
                    yield return node;
                }

                IEnumerable<DocCommentNode> Inlined(DocCommentInheritDoc doc)
                {
                    var source = doc.Cref is null or "" ? Base(member) : Cref(member, doc.Cref);

                    // We need to inline all comments in `source` to support complex chains
                    // (e.g., `C` inherits `B` which inherits `A`).
                    return source is not null
                        ? Merge(member.Comment.Nodes, Inline(source).Comment.Nodes)
                        : Enumerable.Empty<DocCommentNode>();

                    IEnumerable<DocCommentNode> Merge(IEnumerable<DocCommentNode> source, IEnumerable<DocCommentNode> inherit) =>
                        source.Where(x => x is not DocCommentInheritDoc).Concat(inherit);
                }
            }
        }

        DocMember? Base(DocMember? x)
        {
            if (x is null)
                return null;

            if (x is DocTypeDeclaration declaration)
                return declaration.Base.Select(Declaration).FirstOrDefault(x => x is not null);

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

                var declaration = Declaration(type);
                if (declaration is null)
                    return null;

                var check = new Stack<DocType>();

                PushBase();

                while (check.Count > 0)
                {
                    type = check.Pop();
                    declaration = Declaration(type);

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
                return declaration.Base.SelectMany(Declarations).FirstOrDefault(x => x is not null && x.FullyQualifiedName.EndsWith(cref));

            if (x is DocMethod method)
                return Ref(method.DeclaringType);

            if (x is DocField field)
                return Ref(field.DeclaringType);

            if (x is DocProperty prop)
                return Ref(prop.DeclaringType);

            if (x is DocIndexer indexer)
                return Ref(indexer.DeclaringType);

            return null;

            DocMember? Ref(DocType? type)
            {
                if (cref.Split('.') is [_, .., var name])
                {
                    var full = cref.Substring(0, cref.Length - name.Length - 1);

                    return Declarations(type)
                        .NonNulls()
                        .FirstOrDefault(x => x.FullyQualifiedName.EndsWith(full))?
                        .Members
                        .FirstOrDefault(x => x.Cref == name);
                }
                else
                {
                    return Declaration(type)?.Members.FirstOrDefault(x => x.Cref == cref);
                }
            }
        }

        IEnumerable<DocTypeDeclaration?> Declarations(DocType? type)
        {
            if (type is null)
                yield break;

            var declaration = Declaration(type);
            if (declaration is null)
                yield break;

            yield return declaration;

            foreach (var x in declaration.Base)
            foreach (var y in Declarations(x).Where(z => z is not null))
                yield return y;
        }

        DocTypeDeclaration? Declaration(DocType? type) =>
            type is null ? null : members.OfType<DocTypeDeclaration>().FirstOrDefault(x => x.Name == type.Name);
    }
}