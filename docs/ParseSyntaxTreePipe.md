# [Summary.Roslyn.CSharp.ParseSyntaxTreePipe](../src/Plugins/Roslyn/CSharp/ParseSyntaxTreePipe.cs#L10)
```cs
public class ParseSyntaxTreePipe : IPipe<Source, SyntaxTree>
```

A [`IPipe{I,O}`](./IPipe{I,O}.md) that parses the specified string into a [`SyntaxTree`](./SyntaxTree.md).

## Methods
### [Run(Source)](../src/Plugins/Roslyn/CSharp/ParseSyntaxTreePipe.cs#L12)
```cs
public Task<SyntaxTree> Run(Source input)
```

