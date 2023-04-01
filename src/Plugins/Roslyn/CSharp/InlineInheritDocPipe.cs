using Summary.Pipes;

namespace Summary.Roslyn.CSharp;

public class InlineInheritDocPipe : IPipe<Doc[], Doc>
{
    // TODO: [x] Base types
    // TODO: [ ] Base interfaces
    // TODO: [ ] Base methods
    // TODO: [ ] Crefs
    // TODO: [ ] Complex merging rules
    public Task<Doc> Run(Doc[] input)
    {
        var members = input.SelectMany(x => x.Members).ToArray();
        var inlined = members.Select(Inline).ToArray();

        return Task.FromResult(new Doc(inlined));

        DocMember Inline(DocMember member)
        {
            return member with { Comment = new DocComment(member.Comment.Nodes.SelectMany(Inline).ToArray()) };

            IEnumerable<DocCommentNode> Inline(DocCommentNode node)
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

                    return Enumerable.Empty<DocCommentNode>();

                    IEnumerable<DocCommentNode> Merge(IEnumerable<DocCommentNode> source, IEnumerable<DocCommentNode> inherit) =>
                        source.Where(x => x is not DocCommentInheritDoc).Concat(inherit);
                }
            }
        }

        DocMember? Base(DocMember x)
        {
            if (x is DocTypeDeclaration type)
            {
                foreach (var @base in type.Base)
                {
                    var declaration = Declaration(@base);
                    if (declaration is not null)
                        return declaration;
                }
            }

            return null;

            DocTypeDeclaration? Declaration(DocType type) =>
                members.OfType<DocTypeDeclaration>().FirstOrDefault(x => x.Name == type.Name);
        }
    }
}