# Summary.Pipes.Filters.FilterMemberPipe
```cs
public class FilterMemberPipe : IPipe<Doc, Doc>
```

A simple pipe that filters all members inside the document using the specified predicate
and then applies the given map function on them.

## Methods
### Run(Doc)
```cs
public Task<Doc> Run(Doc input)
```

