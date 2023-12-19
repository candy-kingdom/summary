# [Summary.Roslyn.CSharp.ParseDocPipe](../src/Plugins/Roslyn/CSharp/ParseDocPipe.cs#L12)
```cs
public class ParseDocPipe : IPipe&lt;SyntaxTree, Doc&gt;
```

A [`IPipe&lt;I, O&gt;`](./Summary.Pipes.IPipe{I,O}.md) that transforms the specified syntax tree into parsed document.

## Methods
### [Run(SyntaxTree)](../src/Plugins/Roslyn/CSharp/ParseDocPipe.cs#L14)
```cs
public async Task&lt;Doc&gt; Run(SyntaxTree input)
```

