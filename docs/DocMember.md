# [Summary.DocMember](../src/Core/DocMember.cs#L7)
```cs
public abstract record DocMember
```

A member of the generated document (e.g. type, field, property, method, etc.).

## Properties
### [FullyQualifiedName](../src/Core/DocMember.cs#L12)
```cs
public required string FullyQualifiedName { get; init; }
```

The fully qualified name of the member (e.g., `Summary.DocMember`).

### [Name](../src/Core/DocMember.cs#L17)
```cs
public required string Name { get; init; }
```

The name of the member (e.g. `public int Field` has name `Field`).

### [Declaration](../src/Core/DocMember.cs#L23)
```cs
public required string Declaration { get; init; }
```

The code-snippet that contains the full declaration of the member
(e.g. `public int Field` is a declaration of the field member `Field`).

### [Access](../src/Core/DocMember.cs#L28)
```cs
public required AccessModifier Access { get; init; }
```

The access modifier of the member.

### [Comment](../src/Core/DocMember.cs#L33)
```cs
public required DocComment Comment { get; init; }
```

The documentation comment of the member (can be empty).

### [DeclaringType](../src/Core/DocMember.cs#L38)
```cs
public required DocType? DeclaringType { get; init; }
```

The type that this member is declared in (works for nested types as well).

### [Deprecated](../src/Core/DocMember.cs#L44)
```cs
[MemberNotNullWhen(true, nameof(Deprecation))]
public bool Deprecated { get; }
```

Whether the member is deprecated (e.g. marked with `[Obsolete]`).

### [Deprecation](../src/Core/DocMember.cs#L49)
```cs
public DocDeprecation? Deprecation { get; init; }
```

The member deprecation information.

### [Location](../src/Core/DocMember.cs#L54)
```cs
public DocLocation? Location { get; init; }
```

The location of the member.

## Methods
### [MatchesCref(string)](../src/Core/DocMember.cs#L59)
```cs
public bool MatchesCref(string cref)
```

Whether this member matches the specified `cref` reference.

