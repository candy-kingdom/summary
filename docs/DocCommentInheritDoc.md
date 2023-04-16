# Summary.DocCommentInheritDoc
A [`DocCommentNode`](./DocCommentNode.md) that inherits documentation from another member
(`<inheritdoc>`).

```cs
public record DocCommentInheritDoc(string? Cref) : DocCommentNode
```

## Properties
### Cref
An optional link to the member the documentation should be inherited from.

```cs
public string? Cref { get; }
```

