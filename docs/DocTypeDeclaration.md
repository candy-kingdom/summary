# DocTypeDeclaration
A [`DocMember`](./DocMember.md) that represents a documented type declaration (e.g. `struct`, `class`, etc.)
in the parsed source code.

```cs
public record DocTypeDeclaration(
    string Name,
    string Declaration,
    AccessModifier Access,
    DocComment Comment,
    DocMember[] Members,
    DocTypeParam[] TypeParams) : DocMember(Name, Declaration, Access, Comment)
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

### TypeParams
```cs
public DocTypeParam[] TypeParams { get; }
```

