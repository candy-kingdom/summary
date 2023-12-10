# [Summary.DocType](../src/Core/DocType.cs#L9)
```cs
public record DocType(string Name, DocType[] TypeParams)
```

A simple type (e.g. `int`, `string`, `List<int>`, etc.).

## Properties
### FullName
```cs
public string FullName { get; }
```

The full name of the type including its type parameters.

### Name
```cs
public string Name { get; }
```

The name of the type (without generic arguments).

### TypeParams
```cs
public DocType[] TypeParams { get; }
```

The generic parameters of this type (if it's generic).

