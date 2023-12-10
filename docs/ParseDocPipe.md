# [Summary.Roslyn.CSharp.ParseDocPipe](../src/Plugins/Roslyn/CSharp/ParseDocPipe.cs#L11)
```cs
public class ParseDocPipe : IPipe<SyntaxTree, Doc>
```

A [`IPipe{I,O}`](./IPipe{I,O}.md) that transforms the specified syntax tree into parsed document.

## Methods
### Run(SyntaxTree)
```cs
public async Task<Doc> Run(SyntaxTree input)
```

