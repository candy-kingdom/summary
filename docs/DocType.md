# [Summary.DocType](../src/Core/DocType.cs#L11)
```cs
public record DocType(string Name, DocType[] TypeParams, string? FullyQualifiedName = null)
```

A simple type (e.g. `int`, `string`, `List<int>`, etc.).

## Properties
### [FullName](../src/Core/DocType.cs#L16)
```cs
public string FullName { get; }
```

The full name of the type including its type parameters.

### [Name](../src/Core/DocType.cs#L11)
```cs
public string Name { get; }
```

The name of the type (without generic arguments).

### [TypeParams](../src/Core/DocType.cs#L11)
```cs
public DocType[] TypeParams { get; }
```

The generic parameters of this type (if it's generic).

### [FullyQualifiedName](../src/Core/DocType.cs#L11)
```cs
public string? FullyQualifiedName { get; }
```

An optional fully qualified name (`null` for parameter or field types).

