# [Summary.Roslyn.CSharp.InlineInheritDocPipe](../src/Plugins/Roslyn/CSharp/InlineInheritDocPipe.cs#L18)
```cs
public class InlineInheritDocPipe : IPipe&lt;Doc, Doc&gt;
```

A [`IPipe&lt;I, O&gt;`](./Summary.Pipes.IPipe{I,O}.md) that inlines `&lt;inheritdoc/&gt;` tags.

_Under the hood, the process of inlining works as follows:_
_&lt;br /&gt;_
_- each member in the [`Doc`](./Summary.Doc.md) is analyzed_
_- if this member contains an `&lt;inheritdoc/&gt;` element, it's removed from the member comment_
_- then, the inherited documentation (either from the base type or from the specified cref) is added to the member comment._

## Methods
### [Run(Doc)](../src/Plugins/Roslyn/CSharp/InlineInheritDocPipe.cs#L20)
```cs
public Task&lt;Doc&gt; Run(Doc doc)
```

