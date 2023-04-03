# DocMethod
A [`DocMember`](./DocMember.md) that represents a documented method in the parsed source code.

```cs
public record DocMethod : DocMember
```

## Properties
### TypeParams
The type parameters of the method.

```cs
public required DocTypeParam[] TypeParams { get; init; }
```

### Params
The parameters of the method.

```cs
public required DocParam[] Params { get; init; }
```

### Delegate
Whether this method represents a delegate.

```cs
public required bool Delegate { get; init; }
```

### SignatureWithoutParams
The signature of the method without parameters in link format (e.g., `Sum{T}`).

```cs
public string SignatureWithoutParams { get; }
```

### Signature
The signature of the method in link format (e.g., `Sum{T}(T, T)`).

```cs
public string Signature { get; }
```

