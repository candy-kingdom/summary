# [Summary.DocEvent](../src/Core/DocEvent.cs#L9)
```cs
public record DocEvent : DocMember
```

A [`DocMember`](./Summary.DocMember.md) that represents a documented event in the parsed source code.

_Similar to [`DocProperty`](./Summary.DocProperty.md) but with its own set of accessors._

## Properties
### [Type](../src/Core/DocEvent.cs#L14)
```cs
public required DocType Type { get; init; }
```

The type of the event.

