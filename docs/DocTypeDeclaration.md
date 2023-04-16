# Summary.DocTypeDeclaration
A [`DocMember`](./DocMember.md) that represents a documented type declaration (e.g. `struct`, `class`, etc.)
in the parsed source code.

```cs
public record DocTypeDeclaration : DocMember
```

## Properties
### Members
The members of this type (e.g. fields, properties, methods).

```cs
public required DocMember[] Members { get; init; }
```

### TypeParams
The type parameters of this type (if it's generic).

```cs
public required DocTypeParam[] TypeParams { get; init; }
```

### Base
The list of base types for this one.

```cs
public required DocType[] Base { get; init; }
```

### Record
Whether this type declaration is a record declaration.

```cs
public required bool Record { get; init; }
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

