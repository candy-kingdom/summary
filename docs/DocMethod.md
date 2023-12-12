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

### [Signature](../src/Core/DocMethod.cs#L29)
```cs
public string Signature { get; }
```

The full signature of the method that includes both type parameters and regular parameters
(e.g., `"Method<T1, T2>(int, short)"`).

### [FullyQualifiedSignature](../src/Core/DocMethod.cs#L36)
```cs
public string FullyQualifiedSignature { get; }
```

The full signature of the method that includes both type parameters and regular parameters
(e.g., `"Method<T1, T2>(int, short)"`).

