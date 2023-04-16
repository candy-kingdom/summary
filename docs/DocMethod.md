# Summary.DocMethod
```cs
public record DocMethod : DocMember
```

A [`DocMember`](./DocMember.md) that represents a documented method in the parsed source code.

## Properties
### TypeParams
```cs
public required DocTypeParam[] TypeParams { get; init; }
```

The type parameters of the method.

### Params
```cs
public required DocParam[] Params { get; init; }
```

The parameters of the method.

### Delegate
```cs
public required bool Delegate { get; init; }
```

Whether this method represents a delegate.

### SignatureWithoutParams
```cs
public string SignatureWithoutParams { get; }
```

The signature of the method without parameters in link format (e.g., `Sum{T}`).

### Signature
```cs
public string Signature { get; }
```

The signature of the method in link format (e.g., `Sum{T}(T, T)`).

