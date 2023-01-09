# FilterPublicMembersPipe
A [`IPipe{I,O}`](./IPipe{I,O}.md) that filters out non-public types and members from the parsed document.

```cs
public class FilterPublicMembersPipe : IPipe<Doc, Doc>
```

## Methods
### Run
```cs
public Task<Doc> Run(Doc input)
```

