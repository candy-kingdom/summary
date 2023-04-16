# Summary.DocCommentParamRef
A [`DocCommentNode`](./DocCommentNode.md) that represents the reference to a parameter (`<paramref>`, `<typeparamref>`).

```cs
public record DocCommentParamRef(string Value) : DocCommentNode
```

## Properties
### Value
The name of the parameter .

```cs
public string Value { get; }
```

