using Summary.Pipes;

namespace Summary.Roslyn.CSharp;

public class InlineInheritDocPipe : IPipe<Doc[], Doc>
{
    // TODO: [x] Base types (1 level)
    // TODO: [ ] Base types (n levels)
    // TODO: [x] Base interfaces
    // TODO: [x] Base methods
    // TODO: [ ] Crefs
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

            if (x is DocMethod method)
            {
                if (method.DeclaringType is not null)
                {
                    var declaring = Declaration(method.DeclaringType);
                    if (declaring is not null)
                    {
                        if (Base(declaring) is DocTypeDeclaration @base)
                            return @base.Members.OfType<DocMethod>().FirstOrDefault(x => x.Name == method.Name);
                    }
                }
            }

            return null;

            DocTypeDeclaration? Declaration(DocType type) =>
                members.OfType<DocTypeDeclaration>().FirstOrDefault(x => x.Name == type.Name);
        }
    }
}