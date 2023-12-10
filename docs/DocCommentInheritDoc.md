# [Summary.DocCommentInheritDoc](../src/Core/DocCommentInheritDoc.cs#L8)
```cs
public record DocCommentInheritDoc(string? Cref) : DocCommentNode
```

A [`DocCommentNode`](./DocCommentNode.md) that inherits documentation from another member
(`<inheritdoc>`).

## Properties
### [Cref](../src/Core/DocCommentInheritDoc.cs#L8)
```cs
public string? Cref { get; }
```

An optional link to the member the documentation should be inherited from.

