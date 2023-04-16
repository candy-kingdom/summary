# Summary.DocType
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
The name of the type (without generic arguments).

```cs
public string Name { get; }
```

### TypeParams
The generic parameters of this type (if it's generic).

```cs
public DocType[] TypeParams { get; }
```

