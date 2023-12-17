# [Summary.DocCommentParamRef](../src/Core/DocCommentParamRef.cs#L8)
```cs
public record DocCommentParamRef(string Value) : DocCommentNode
```

A [`DocCommentNode`](./Summary.DocCommentNode.md) that represents the reference to a parameter
(`<paramref>`, `<typeparamref>`).

## Properties
### [Value](../src/Core/DocCommentParamRef.cs#L8)
```cs
public string Value { get; }
```

The name of the parameter.

