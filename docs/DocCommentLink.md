# DocCommentLink
A [`DocCommentNode`](./DocCommentNode.md) that represents the link to other member (e.g. `<see cref="SomeMember"/>`).

```cs
public record DocCommentLink(string Value) : DocCommentNode
```

## Properties
### Value
The name of the member the link links to.

```cs
 string Value { get; }
```

