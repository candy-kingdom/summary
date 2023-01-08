using Doc.Net.Core.Pipes;
using static Doc.Net.Core.AccessModifier;

namespace Doc.Net.Core.Filters;

/// <summary>
///     A <see cref="IPipe{I,O}"/> that filters out non-public types and members from the parsed document.
/// </summary>
public class PublicFilterPipe : IPipe<Document, Document>
{
    public Task<Document> Run(Document input) =>
        Task.FromResult(new Document(Filtered(input.Members)));

    private static DocMember[] Filtered(DocMember[] members) =>
        members
            .Where(x => x.Access is Public)
            .Select(Filtered)
            .ToArray();

    private static DocMember Filtered(DocMember member) => member switch
    {
        DocType type => type with { Members = Filtered(type.Members) },

        _ => member,
    };
}