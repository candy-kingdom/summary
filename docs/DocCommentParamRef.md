# Summary.DocCommentParamRef
```cs
public record DocCommentParamRef(string Value) : DocCommentNode
```

A [`DocCommentNode`](./DocCommentNode.md) that represents the reference to a parameter (`<paramref>`, `<typeparamref>`).

## Properties
### Value
```cs
public string Value { get; }
```

The name of the parameter .

