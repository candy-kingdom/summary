# [Summary.DocCommentLink](../src/Core/DocCommentLink.cs#L9)
```cs
public record DocCommentLink(DocMember? Member, string Value) : DocCommentNode
```

A [`DocCommentNode`](./Summary.DocCommentNode.md) that represents the link to other member (e.g. `&lt;see cref="SomeMember"/&gt;`).

## Properties
### [Member](../src/Core/DocCommentLink.cs#L9)
```cs
public DocMember? Member { get; }
```

The doc member the link references to.

### [Value](../src/Core/DocCommentLink.cs#L9)
```cs
public string Value { get; }
```

The name of the member the link links to.

