# DocMember
A member of the generated document (e.g. type, field, property, method, etc.).

```cs
public abstract record DocMember
```

## Properties
### FullyQualifiedName
The fully qualified name of the member.

```cs
public required string FullyQualifiedName { get; init; }
```

### Name
The name of the member (e.g. `public int Field` has name `Field`).

```cs
public required string Name { get; init; }
```

### Declaration
The code-snippet that contains the full declaration of the member
(e.g. `public int Field` is a declaration of the field member `Field`).

```cs
public required string Declaration { get; init; }
```

### Access
The access modifier of the member.

```cs
public required AccessModifier Access { get; init; }
```

### Comment
The documentation comment of the member (can be empty).

```cs
public required DocComment Comment { get; init; }
```

### DeclaringType
The type that this member is declared in (works for nested types as well).

```cs
public required DocType? DeclaringType { get; init; }
```

## Methods
### MatchesCref(string)
Whether this member matches the specified `cref` reference.

```cs
public bool MatchesCref(string cref)
```

