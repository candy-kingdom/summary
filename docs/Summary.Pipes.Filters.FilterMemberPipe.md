# [Summary.Pipes.Filters.FilterMemberPipe](../src/Core/Pipes/Filters/FilterMemberPipe.cs#L6)
```cs
public class FilterMemberPipe : IPipe<Doc, Doc>
```

A simple pipe that filters all members inside the document using the specified predicate.

## Methods
### [Run(Doc)](../src/Core/Pipes/Filters/FilterMemberPipe.cs#L9)
```cs
public Task<Doc> Run(Doc input)
```

Asynchronously processes the specified input and returns the output.
