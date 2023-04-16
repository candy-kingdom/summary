# Summary.DocField
```cs
public record DocField : DocMember
```

A [`DocMember`](./DocMember.md) that represents a documented field in the parsed source code.

## Properties
### Type
```cs
public required DocType Type { get; init; }
```

The type of the field.

