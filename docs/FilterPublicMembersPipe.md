# Summary.Pipes.Filters.FilterPublicMembersPipe
```cs
public class FilterPublicMembersPipe : IPipe<Doc, Doc>
```

A [`IPipe{I,O}`](./IPipe{I,O}.md) that filters out non-public types and members from the parsed document.

## Methods
### Run(Doc)
```cs
public Task<Doc> Run(Doc input)
```

