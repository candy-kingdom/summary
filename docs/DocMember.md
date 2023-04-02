# DocMember
A member of the generated document (e.g. type, field, property, method, etc.).

```cs
public record DocMember(string Name, string Declaration, AccessModifier Access, DocComment Comment)
```

## Properties
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

## Methods
### MatchesCref(string)
```cs
public bool MatchesCref(string cref)
```

