# [Summary.DocCommentLink](../src/Core/DocCommentLink.cs#L7)
```cs
public record DocCommentLink(string Value) : DocCommentNode
```

A [`DocCommentNode`](./DocCommentNode.md) that represents the link to other member (e.g. `<see cref="SomeMember"/>`).

## Properties
### Value
```cs
public string Value { get; }
```

The name of the member the link links to.

