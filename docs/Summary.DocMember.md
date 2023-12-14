# [Summary.DocMember](../src/Core/DocMember.cs#L8)
```cs
public abstract record DocMember
```

A member of the generated document (e.g. type, field, property, method, etc.).

## Properties
### [Namespace](../src/Core/DocMember.cs#L13)
```cs
public required string Namespace { get; init; }
```

The namespace the member is defined in.

### [FullyQualifiedName](../src/Core/DocMember.cs#L18)
```cs
public required string FullyQualifiedName { get; init; }
```

The fully qualified name of the member (e.g., `Summary.DocMember`).

### [Name](../src/Core/DocMember.cs#L23)
```cs
public required string Name { get; init; }
```

The name of the member (e.g. `public int Field` has name `Field`).

### [Declaration](../src/Core/DocMember.cs#L29)
```cs
public required string Declaration { get; init; }
```

The code-snippet that contains the full declaration of the member
(e.g. `public int Field` is a declaration of the field member `Field`).

### [Access](../src/Core/DocMember.cs#L34)
```cs
public required AccessModifier Access { get; init; }
```

The access modifier of the member.

### [DeclaringType](../src/Core/DocMember.cs#L39)
```cs
public required DocType? DeclaringType { get; init; }
```

The type that this member is declared in (works for nested types as well).

### [Comment](../src/Core/DocMember.cs#L44)
```cs
public DocComment Comment { get; set; }
```

The documentation comment of the member (can be empty).

### [Deprecated](../src/Core/DocMember.cs#L50)
```cs
[MemberNotNullWhen(true, nameof(Deprecation))]
public bool Deprecated { get; }
```

Whether the member is deprecated (e.g. marked with `[Obsolete]`).

### [Deprecation](../src/Core/DocMember.cs#L55)
```cs
public DocDeprecation? Deprecation { get; init; }
```

The member deprecation information.

### [Location](../src/Core/DocMember.cs#L60)
```cs
public DocLocation? Location { get; init; }
```

The location of the member.

### [Usings](../src/Core/DocMember.cs#L65)
```cs
public required string[] Usings { get; init; }
```

The list of `using` statements imported in the scope of this type declaration.

