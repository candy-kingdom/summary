# DocType
A [`DocMember`](./DocMember.md) that represents a documented type in the parsed source code.

```cs
public record DocType(string Name, string Declaration, AccessModifier Access, DocComment Comment, DocMember[] Members) : DocMember(Name, Declaration, Access, Comment)
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

### Members
```cs
public DocMember[] Members { get; }
```

