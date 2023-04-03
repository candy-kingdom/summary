# DocTypeDeclaration
A [`DocMember`](./DocMember.md) that represents a documented type declaration (e.g. `struct`, `class`, etc.)
in the parsed source code.

```cs
public record DocTypeDeclaration(
    string FullyQualifiedName,
    string Name,
    string Declaration,
    AccessModifier Access,
    DocComment Comment,
    DocType? DeclaringType,
    DocMember[] Members,
    DocTypeParam[] TypeParams,
    DocType[] Base,
    bool Record = false) : DocMember(FullyQualifiedName, Name, Declaration, Access, Comment, DeclaringType)
```

## Properties
### FullyQualifiedName
```cs
public string FullyQualifiedName { get; }
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

### DeclaringType
The type that this member is declared in (works for nested types as well).

```cs
public DocType? DeclaringType { get; }
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

### Base
The list of base types for this one.

```cs
public DocType[] Base { get; }
```

### Record
```cs
public bool Record { get; }
```

## Methods
### MembersOfType(DocMember)
A sequence of members of this type declaration that has the same type as the specified one.

```cs
public IEnumerable<DocMember> MembersOfType(DocMember member)
```

### BaseDeclarationsAndSelf(Doc)
This type declaration and the sequence of type declarations that are base types of this one.

_This method is recursive and will return the sequence of all base types, even non-direct ones._

```cs
public IEnumerable<DocTypeDeclaration> BaseDeclarationsAndSelf(Doc doc)
```

### BaseDeclarations(Doc)
A sequence of type declarations that are base types of this one.

_This method is recursive and will return the sequence of all base types, even non-direct ones._

```cs
public IEnumerable<DocTypeDeclaration> BaseDeclarations(Doc doc)
```

