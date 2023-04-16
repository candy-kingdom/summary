# Summary.DocMember
```cs
public abstract record DocMember
```

A member of the generated document (e.g. type, field, property, method, etc.).

## Properties
### FullyQualifiedName
```cs
public required string FullyQualifiedName { get; init; }
```

The fully qualified name of the member.

### Name
```cs
public required string Name { get; init; }
```

The name of the member (e.g. `public int Field` has name `Field`).

### Declaration
```cs
public required string Declaration { get; init; }
```

The code-snippet that contains the full declaration of the member
(e.g. `public int Field` is a declaration of the field member `Field`).

### Access
```cs
public required AccessModifier Access { get; init; }
```

The access modifier of the member.

### Comment
```cs
public required DocComment Comment { get; init; }
```

The documentation comment of the member (can be empty).

### DeclaringType
```cs
public required DocType? DeclaringType { get; init; }
```

The type that this member is declared in (works for nested types as well).

## Methods
### MatchesCref(string)
```cs
public bool MatchesCref(string cref)
```

Whether this member matches the specified `cref` reference.

