# [Summary.Roslyn.CSharp.ParseSyntaxTreePipe](../src/Plugins/Roslyn/CSharp/ParseSyntaxTreePipe.cs#L11)
```cs
public class ParseSyntaxTreePipe : IPipe<Source, SyntaxTree>
```

A [`IPipe{I,O}`](./IPipe{I,O}.md) that parses the specified string into a <u>`SyntaxTree`</u>.

## Methods
### [Run(Source)](../src/Plugins/Roslyn/CSharp/ParseSyntaxTreePipe.cs#L13)
```cs
public Task<SyntaxTree> Run(Source input)
```

