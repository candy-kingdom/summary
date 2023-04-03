# DocDelegate
```cs
public record DocDelegate(
    string FullyQualifiedName,
    string Name,
    string Declaration,
    AccessModifier Access,
    DocComment Comment,
    DocParam[] Params,
    DocTypeParam[] TypeParams,
    DocType? DeclaringType) : DocMethod(FullyQualifiedName, Name, Declaration, Access, Comment, DeclaringType, Params,
    TypeParams)
```

## Properties
### FullyQualifiedName
```cs
public string FullyQualifiedName { get; }
```

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

