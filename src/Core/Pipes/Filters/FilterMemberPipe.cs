namespace Summary.Pipes.Filters;

/// <summary>
///     A simple pipe that filters all members inside the document using the specified predicate
///     and then applies the given map function on them.
/// </summary>
public class FilterMemberPipe(Func<DocMember, bool> predicate, Func<DocMember, DocMember>? map = null) : IPipe<Doc, Doc>
{
    private readonly Func<DocMember, DocMember> _map = map ?? (static x => x);

    /// <inheritdoc />
    public Task<Doc> Run(Doc input) =>
        Task.FromResult(new Doc(Filtered(input.Members)));

    private DocMember[] Filtered(DocMember[] members) =>
        members
            .Where(predicate)
            .Select(Filtered)
            .Select(_map)
            .ToArray();

    private DocMember Filtered(DocMember member) => member switch
    {
        DocTypeDeclaration type => type with { Members = Filtered(type.Members) },

        _ => member,
    };
}