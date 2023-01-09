# ParseDocPipe
A [`IPipe{I,O}`](./IPipe{I,O}.md) that transforms the specified syntax tree into parsed document.

```cs
public class ParseDocPipe : IPipe<SyntaxTree, Doc>
```

## Methods
### Run
```cs
public async Task<Doc> Run(SyntaxTree input)
```

