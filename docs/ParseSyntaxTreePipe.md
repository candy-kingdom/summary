# Summary.Roslyn.CSharp.ParseSyntaxTreePipe
```cs
public class ParseSyntaxTreePipe : IPipe<string, SyntaxTree>
```

A [`IPipe{I,O}`](./IPipe{I,O}.md) that parses the specified string into a [`SyntaxTree`](./SyntaxTree.md).

## Methods
### Run(string)
```cs
public Task<SyntaxTree> Run(string input)
```

