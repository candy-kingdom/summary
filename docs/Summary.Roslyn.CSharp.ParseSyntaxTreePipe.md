# [Summary.Roslyn.CSharp.ParseSyntaxTreePipe](../src/Plugins/Roslyn/CSharp/ParseSyntaxTreePipe.cs#L11)
```cs
public class ParseSyntaxTreePipe : IPipe&lt;Source, SyntaxTree&gt;
```

A [`IPipe&lt;I, O&gt;`](./Summary.Pipes.IPipe{I,O}.md) that parses the specified string into a &lt;u&gt;`SyntaxTree`&lt;/u&gt;.

## Methods
### [Run(Source)](../src/Plugins/Roslyn/CSharp/ParseSyntaxTreePipe.cs#L13)
```cs
public Task&lt;SyntaxTree&gt; Run(Source input)
```

