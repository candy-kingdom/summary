# DocIndexer
```cs
public record DocIndexer(
        DocType Type,
        string Name,
        string Declaration,
        AccessModifier Access,
        DocComment Comment,
        DocType? DeclaringType,
        DocParam[] Params) : DocMember(Name, Declaration, Access, Comment, DeclaringType)
```

## Properties
### Type
```cs
public DocType Type { get; }
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

### DeclaringType
```cs
public DocType? DeclaringType { get; }
```

### Params
```cs
public DocParam[] Params { get; }
```

