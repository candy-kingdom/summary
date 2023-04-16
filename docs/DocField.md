# Summary.DocField
A [`DocMember`](./DocMember.md) that represents a documented field in the parsed source code.

```cs
public record DocField : DocMember
```

## Properties
### Type
The type of the field.

```cs
public required DocType Type { get; init; }
```

