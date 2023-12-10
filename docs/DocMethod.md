# [Summary.DocMethod](../src/Core/DocMethod.cs#L8)
```cs
public record DocMethod : DocMember
```

A [`DocMember`](./DocMember.md) that represents a documented method in the parsed source code.

## Properties
### [TypeParams](../src/Core/DocMethod.cs#L13)
```cs
public required DocTypeParam[] TypeParams { get; init; }
```

The type parameters of the method.

### [Params](../src/Core/DocMethod.cs#L18)
```cs
public required DocParam[] Params { get; init; }
```

The parameters of the method.

### [Delegate](../src/Core/DocMethod.cs#L23)
```cs
public required bool Delegate { get; init; }
```

Whether this method represents a delegate.

### [SignatureWithoutParams](../src/Core/DocMethod.cs#L28)
```cs
public string SignatureWithoutParams { get; }
```

The signature of the method without parameters in link format (e.g., `Sum{T}`).

### [Signature](../src/Core/DocMethod.cs#L33)
```cs
public string Signature { get; }
```

The signature of the method in link format (e.g., `Sum{T}(T, T)`).

