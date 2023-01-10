# DocMethod
A [`DocMember`](./DocMember.md) that represents a documented method in the parsed source code.

```cs
public record DocMethod(string Name, string Declaration, AccessModifier Access, DocComment Comment, DocParam[] Params) : DocMember(Name, Declaration, Access, Comment)
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

### Params
```cs
 DocParam[] Params { get; }
```

