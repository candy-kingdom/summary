# [Summary.DocCommentParamRef](../src/Core/DocCommentParamRef.cs#L6)
```cs
public record DocCommentParamRef(string Value) : DocCommentNode
```

A [`DocCommentNode`](./DocCommentNode.md) that represents the reference to a parameter (`<paramref>`, `<typeparamref>`).

## Properties
### [Value](../src/Core/DocCommentParamRef.cs#L6)
```cs
public string Value { get; }
```

The name of the parameter .

