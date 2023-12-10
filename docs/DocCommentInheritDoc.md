# [Summary.DocCommentInheritDoc](../src/Core/DocCommentInheritDoc.cs#L7)
```cs
public record DocCommentInheritDoc(string? Cref) : DocCommentNode
```

A [`DocCommentNode`](./DocCommentNode.md) that inherits documentation from another member
(`<inheritdoc>`).

## Properties
### Cref
```cs
public string? Cref { get; }
```

An optional link to the member the documentation should be inherited from.

