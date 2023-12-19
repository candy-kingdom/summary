# [Summary.Pipes.Filters.FilterMemberPipe](../src/Core/Pipes/Filters/FilterMemberPipe.cs#L7)
```cs
public class FilterMemberPipe : IPipe&lt;Doc, Doc&gt;
```

A simple pipe that filters all members inside the document using the specified predicate
and then applies the given map function on them.

## Methods
### [Run(Doc)](../src/Core/Pipes/Filters/FilterMemberPipe.cs#L12)
```cs
public Task&lt;Doc&gt; Run(Doc input)
```

Asynchronously processes the specified input and returns the output.

