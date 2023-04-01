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
    // TODO: [ ] Crefs: base types (methods)
    // TODO: [ ] Crefs: base types (types)
    // TODO: [ ] Base indexers
    // TODO: [ ] Base events
    // TODO: [ ] Complex merging rules
    // TODO: [ ] Base types (n levels)
    // TODO: [ ] Inheriting inherited docs?
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
                    if (doc.Cref is null or "")
                    {
                        var @base = Base(member);
                        if (@base is not null)
                            return Merge(member.Comment.Nodes, @base.Comment.Nodes);
                    }
                    else
                    {
                        var cref = Cref(member, doc.Cref);
                        if (cref is not null)
                            return Merge(member.Comment.Nodes, cref.Comment.Nodes);
                    }

                    return Enumerable.Empty<DocCommentNode>();

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

            return null;

            DocMember? ByType<T>(T member, DocType? type) where T : DocMember =>
                type is not null
                    ? Base(Declaration(type)) is DocTypeDeclaration @base
                        ? @base.Members.OfType<T>().FirstOrDefault(x => x.Name == member.Name)
                        : null
                    : null;

        }

        // TODO: Should check cases where method tries to inherit type documentation?
        DocMember? Cref(DocMember x, string cref)
        {
            // TODO: [x] Search this type.
            // TODO: [ ] Search base types.

            if (x is DocTypeDeclaration declaration)
                return declaration.Base.Select(Declaration).FirstOrDefault(x => x is not null && x.Cref == cref);

            if (x is DocMethod method)
                return Ref(method.DeclaringType);

            if (x is DocField field)
                return Ref(field.DeclaringType);

            if (x is DocProperty prop)
                return Ref(prop.DeclaringType);

            return null;

            DocMember? Ref(DocType? type) =>
                type is not null ? Declaration(type)?.Members.FirstOrDefault(x => x.Cref == cref) : null;
        }

        DocTypeDeclaration? Declaration(DocType type) =>
            members.OfType<DocTypeDeclaration>().FirstOrDefault(x => x.Name == type.Name);
    }
}