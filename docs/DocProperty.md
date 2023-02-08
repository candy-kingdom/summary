# DocProperty
A [`DocMember`](./DocMember.md) that represents a documented property in the parsed source code.

```cs
public record DocProperty(DocType Type, string Name, string Declaration, AccessModifier Access, DocComment Comment) : DocMember(Name, Declaration, Access, Comment)
```

## Properties
### Type
The type of the property.

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

