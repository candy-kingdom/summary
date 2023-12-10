# [Summary.DocField](../src/Core/DocField.cs#L6)
```cs
public record DocField : DocMember
```

A [`DocMember`](./DocMember.md) that represents a documented field in the parsed source code.

## Properties
### [Type](../src/Core/DocField.cs#L11)
```cs
public required DocType Type { get; init; }
```

The type of the field.

