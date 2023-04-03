using Summary.Pipes;

namespace Summary.Roslyn.CSharp;

/// <summary>
///     A <see cref="IPipe{I,O}" /> that inlines <c>&lt;inheritdoc/&gt;</c> tags.
/// </summary>
/// <remarks>
///     Under the hood, the process of inlining works as follows:
///     <br />
///     - each member in the <see cref="Doc" /> is analyzed
///     - if this member contains an <c>&lt;inheritdoc/&gt;</c> element, it's removed from the member comment
///     - then, the inherited documentation (either from the base type or from the specified cref) is added to the member comment.
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
                comment with
                {
                    Nodes = comment.Nodes
                        .OrderBy(x => x is DocCommentInheritDoc)
                        .SelectMany(InlineNode)
                        .ToArray(),
                };

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

        DocMember? Base(DocMember? member)
        {
            if (member is null)
                return null;

            if (member is DocTypeDeclaration declaration)
                return declaration.BaseDeclarations(doc).FirstOrDefault();

            return doc
                .Declaration(member.DeclaringType)?
                .BaseDeclarations(doc)
                .SelectMany(x => x.MembersOfType(member))
                .FirstOrDefault(x => x.Name == member.Name);
        }

        // Here we search a member that matches the given `cref` and is also associated with `x`.
        DocMember? Cref(DocMember member, string cref)
        {
            // Exclude all spaces from the `cref` for better searching.
            cref = cref.Replace(" ", "");

            if (member is DocTypeDeclaration declaration)
                return declaration
                    .BaseDeclarations(doc)
                    .FirstOrDefault(x => x.FullyQualifiedName.EndsWith(cref));

            return Ref(member.DeclaringType);

            DocMember? Ref(DocType? type)
            {
                return doc
                    .Declaration(type)?
                    .BaseDeclarationsAndSelf(doc)
                    .SelectMany(x => x.MembersOfType(member))
                    .FirstOrDefault(x => x.MatchesCref(cref));
            }
        }
    }
}