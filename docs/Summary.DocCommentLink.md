# [Summary.DocCommentLink](../src/Core/DocCommentLink.cs#L8)
```cs
public record DocCommentLink(string Value) : DocCommentNode
```

A [`DocCommentNode`](./Summary.DocCommentNode.md) that represents the link to other member (e.g. `<see cref="SomeMember"/>`).

## Properties
### [Value](../src/Core/DocCommentLink.cs#L8)
```cs
public string Value { get; }
```

The name of the member the link links to.

