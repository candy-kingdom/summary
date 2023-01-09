using static Summary.AccessModifier;

namespace Summary.Pipes.Filters;

/// <summary>
///     A <see cref="IPipe{I,O}"/> that filters out non-public types and members from the parsed document.
/// </summary>
public class FilterPublicMembersPipe : IPipe<Doc, Doc>
{
    public Task<Doc> Run(Doc input) =>
        Task.FromResult(new Doc(Filtered(input.Members)));

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