# [Summary.DocTypeDeclaration](../src/Core/DocTypeDeclaration.cs#L9)
```cs
public record DocTypeDeclaration : DocMember
```

A [`DocMember`](./DocMember.md) that represents a documented type declaration (e.g. `struct`, `class`, etc.)
in the parsed source code.

## Properties
### [Members](../src/Core/DocTypeDeclaration.cs#L14)
```cs
public required DocMember[] Members { get; init; }
```

The members of this type (e.g. fields, properties, methods).

### [TypeParams](../src/Core/DocTypeDeclaration.cs#L19)
```cs
public required DocTypeParam[] TypeParams { get; init; }
```

The type parameters of this type (if it's generic).

### [Base](../src/Core/DocTypeDeclaration.cs#L24)
```cs
public required DocType[] Base { get; init; }
```

The list of base types for this one.

### [Record](../src/Core/DocTypeDeclaration.cs#L29)
```cs
public required bool Record { get; init; }
```

Whether this type declaration is a record declaration.

### [AllMembers](../src/Core/DocTypeDeclaration.cs#L34)
```cs
public IEnumerable<DocMember> AllMembers { get; }
```

All nested members (including children of children) of this type declaration.

## Methods
### [MembersOfType(DocMember)](../src/Core/DocTypeDeclaration.cs#L50)
```cs
public IEnumerable<DocMember> MembersOfType(DocMember member)
```

A sequence of members of this type declaration that has the same type as the specified one.

### [BaseDeclarationsAndSelf(Doc)](../src/Core/DocTypeDeclaration.cs#L59)
```cs
public IEnumerable<DocTypeDeclaration> BaseDeclarationsAndSelf(Doc doc)
```

This type declaration and the sequence of type declarations that are base types of this one.

_This method is recursive and will return the sequence of all base types, even non-direct ones._

### [BaseDeclarations(Doc)](../src/Core/DocTypeDeclaration.cs#L66)
```cs
public IEnumerable<DocTypeDeclaration> BaseDeclarations(Doc doc)
```

A sequence of type declarations that are base types of this one.

_This method is recursive and will return the sequence of all base types, even non-direct ones._

