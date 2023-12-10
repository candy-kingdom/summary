namespace Summary.Pipes.Filters;

/// <summary>
///     A simple pipe that filters all members inside the document using the specified predicate.
/// </summary>
public class FilterMemberPipe(Predicate<DocMember> p) : IPipe<Doc, Doc>
{
    /// <inheritdoc />
    public Task<Doc> Run(Doc input) =>
        Task.FromResult(new Doc(Filtered(input.Members)));

    private DocMember[] Filtered(DocMember[] members) =>
        members
            .Where(x => p(x))
            .Select(Filtered)
            .ToArray();

    private DocMember Filtered(DocMember member) => member switch
    {
        DocTypeDeclaration type => type with { Members = Filtered(type.Members) },

        _ => member,
    };
}