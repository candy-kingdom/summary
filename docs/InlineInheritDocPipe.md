# [Summary.Roslyn.CSharp.InlineInheritDocPipe](../src/Plugins/Roslyn/CSharp/InlineInheritDocPipe.cs#L18)
```cs
public class InlineInheritDocPipe : IPipe<Doc, Doc>
```

A [`IPipe{I,O}`](./IPipe{I,O}.md) that inlines `<inheritdoc/>` tags.

_Under the hood, the process of inlining works as follows:_
_<br />_
_- each member in the [`Doc`](./Doc.md) is analyzed_
_- if this member contains an `<inheritdoc/>` element, it's removed from the member comment_
_- then, the inherited documentation (either from the base type or from the specified cref) is added to the member comment._

## Methods
### [Run(Doc)](../src/Plugins/Roslyn/CSharp/InlineInheritDocPipe.cs#L20)
```cs
public Task<Doc> Run(Doc doc)
```

