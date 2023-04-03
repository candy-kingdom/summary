# DocMethod
A [`DocMember`](./DocMember.md) that represents a documented method in the parsed source code.

```cs
public record DocMethod(
    string Name,
    string Declaration,
    AccessModifier Access,
    DocComment Comment,
    DocType? DeclaringType,
    DocParam[] Params,
    DocTypeParam[] TypeParams) : DocMember(Name, Declaration, Access, Comment, DeclaringType)
```

## Properties
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

### DeclaringType
The type that this member is declared in (works for nested types as well).

```cs
public DocType? DeclaringType { get; }
```

### Params
```cs
public DocParam[] Params { get; }
```

### TypeParams
```cs
public DocTypeParam[] TypeParams { get; }
```

