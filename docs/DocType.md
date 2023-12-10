# [Summary.DocType](../src/Core/DocType.cs#L9)
```cs
public record DocType(string Name, DocType[] TypeParams)
```

A simple type (e.g. `int`, `string`, `List<int>`, etc.).

## Properties
### [FullName](../src/Core/DocType.cs#L14)
```cs
public string FullName { get; }
```

The full name of the type including its type parameters.

### [Name](../src/Core/DocType.cs#L9)
```cs
public string Name { get; }
```

The name of the type (without generic arguments).

### [TypeParams](../src/Core/DocType.cs#L9)
```cs
public DocType[] TypeParams { get; }
```

The generic parameters of this type (if it's generic).

