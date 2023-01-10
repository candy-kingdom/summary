# DocCommentLink
A [`DocCommentNode`](./DocCommentNode.md) that represents the link to other member (e.g. `<see cref="SomeMember"/>`).

```cs
public record DocCommentLink(string Value) : DocCommentNode
```

## Properties
### Value
```cs
 string Value { get; }
```

