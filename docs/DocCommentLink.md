# Summary.DocCommentLink
```cs
public record DocCommentLink(string Value) : DocCommentNode
```

A [`DocCommentNode`](./DocCommentNode.md) that represents the link to other member (e.g. `<see cref="SomeMember"/>`).

## Properties
### Value
The name of the member the link links to.

```cs
public string Value { get; }
```

