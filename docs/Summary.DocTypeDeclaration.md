# [Summary.DocTypeDeclaration](../src/Core/DocTypeDeclaration.cs#L10)
```cs
public record DocTypeDeclaration : DocMember
```

A [`DocMember`](./Summary.DocMember.md) that represents a documented type declaration
(e.g. `struct`, `class`, etc.) in the parsed source code.

## Properties
### [Members](../src/Core/DocTypeDeclaration.cs#L15)
```cs
public required DocMember[] Members { get; init; }
```

The members of this type (e.g. fields, properties, methods).

### [TypeParams](../src/Core/DocTypeDeclaration.cs#L20)
```cs
public required DocTypeParam[] TypeParams { get; init; }
```

The type parameters of this type (if it's generic).

### [Base](../src/Core/DocTypeDeclaration.cs#L25)
```cs
public required DocType[] Base { get; init; }
```

The list of base types for this one.

### [Record](../src/Core/DocTypeDeclaration.cs#L30)
```cs
public required bool Record { get; init; }
```

Whether this type declaration is a record declaration.

### [AllMembers](../src/Core/DocTypeDeclaration.cs#L35)
```cs
public IEnumerable<DocMember> AllMembers { get; }
```

All nested members (including children of children) of this type declaration.

## Methods
### [MembersOfType(DocMember)](../src/Core/DocTypeDeclaration.cs#L41)
```cs
public IEnumerable<DocMember> MembersOfType(DocMember member)
```

A sequence of members of this type declaration that has the same type as the specified one.

