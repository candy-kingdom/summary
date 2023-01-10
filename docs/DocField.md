# DocField
A [`DocMember`](./DocMember.md) that represents a documented field in the parsed source code.

```cs
public record DocField(string Name, string Declaration, AccessModifier Access, DocComment Comment) : DocMember(Name, Declaration, Access, Comment)
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

