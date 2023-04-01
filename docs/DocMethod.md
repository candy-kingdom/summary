# DocMethod
A [`DocMember`](./DocMember.md) that represents a documented method in the parsed source code.

```cs
public record DocMethod(
    string Name,
    string Declaration,
    AccessModifier Access,
    DocComment Comment,
    DocParam[] Params,
    DocTypeParam[] TypeParams,
    DocType? DeclaringType) : DocMember(Name, Declaration, Access, Comment)
```

## Properties
### Name
```cs
public string Name { get; }
```

### Declaration
```cs
public string Declaration { get; }
```

### Access
```cs
public AccessModifier Access { get; }
```

### Comment
```cs
public DocComment Comment { get; }
```

### Params
```cs
public DocParam[] Params { get; }
```

### TypeParams
```cs
public DocTypeParam[] TypeParams { get; }
```

### DeclaringType
```cs
public DocType? DeclaringType { get; }
```

