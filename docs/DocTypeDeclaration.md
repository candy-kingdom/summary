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
    DocTypeParam[] TypeParams,
    DocTypeDeclaration? Parent,
    DocType[] Base) : DocMember(Name, Declaration, Access, Comment)
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
The members of this type (e.g. fields, properties, methods).

```cs
public DocMember[] Members { get; }
```

### TypeParams
The type parameters of this type (if it's generic).

```cs
public DocTypeParam[] TypeParams { get; }
```

### Parent
The containing type this type is defined in (`null` if none).

```cs
public DocTypeDeclaration? Parent { get; }
```

### Base
The list of base types for this one.

```cs
public DocType[] Base { get; }
```

