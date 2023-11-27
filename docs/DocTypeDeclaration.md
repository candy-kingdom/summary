# Summary.DocTypeDeclaration
```cs
public record DocTypeDeclaration : DocMember
```

A [`DocMember`](./DocMember.md) that represents a documented type declaration (e.g. `struct`, `class`, etc.)
in the parsed source code.

## Properties
### Members
```cs
public required DocMember[] Members { get; init; }
```

The members of this type (e.g. fields, properties, methods).

### TypeParams
```cs
public required DocTypeParam[] TypeParams { get; init; }
```

The type parameters of this type (if it's generic).

### Base
```cs
public required DocType[] Base { get; init; }
```

The list of base types for this one.

### Record
```cs
public required bool Record { get; init; }
```

Whether this type declaration is a record declaration.

### AllMembers
```cs
public IEnumerable<DocMember> AllMembers { get; }
```

All nested members (including children of children) of this type declaration.

## Methods
### MembersOfType(DocMember)
```cs
public IEnumerable<DocMember> MembersOfType(DocMember member)
```

A sequence of members of this type declaration that has the same type as the specified one.

### BaseDeclarationsAndSelf(Doc)
```cs
public IEnumerable<DocTypeDeclaration> BaseDeclarationsAndSelf(Doc doc)
```

This type declaration and the sequence of type declarations that are base types of this one.

_This method is recursive and will return the sequence of all base types, even non-direct ones._

### BaseDeclarations(Doc)
```cs
public IEnumerable<DocTypeDeclaration> BaseDeclarations(Doc doc)
```

A sequence of type declarations that are base types of this one.

_This method is recursive and will return the sequence of all base types, even non-direct ones._

