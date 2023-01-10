# DocMember
A member of the generated document (e.g. type, field, property, method, etc.).

```cs
public record DocMember(string Name, string Declaration, AccessModifier Access, DocComment Comment)
```

## Properties
### Name
```cs
 string Name { get; }
```

### Declaration
```cs
 string Declaration { get; }
```

### Access
```cs
 AccessModifier Access { get; }
```

### Comment
```cs
 DocComment Comment { get; }
```

