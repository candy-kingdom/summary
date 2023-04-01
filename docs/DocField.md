# DocField
A [`DocMember`](./DocMember.md) that represents a documented field in the parsed source code.

```cs
public record DocField(DocType Type, string Name, string Declaration, AccessModifier Access, DocComment Comment) : DocMember(Name, Declaration, Access, Comment)
```

## Properties
### Type
The type of the field.

```cs
public DocType Type { get; }
```

### Name
The name of the member (e.g. `public int Field` has name `Field`).

```cs
public string Name { get; }
```

### Declaration
The code-snippet that contains the full declaration of the member
(e.g. `public int Field` is a declaration of the field member `Field`).

```cs
public string Declaration { get; }
```

### Access
The access modifier of the member.

```cs
public AccessModifier Access { get; }
```

### Comment
The documentation comment of the member (can be empty).

```cs
public DocComment Comment { get; }
```

