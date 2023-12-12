# [Summary.DocCommentElementAttribute](../src/Core/DocCommentElementAttribute.cs#L8)
```cs
public record DocCommentElementAttribute(string Name, string Value)
```

An XML-documentation attribute (e.g. `name` in `param`, etc.).

## Properties
### [Name](../src/Core/DocCommentElementAttribute.cs#L8)
```cs
public string Name { get; }
```

The name of the attribute (e.g. `name`, `cref`, etc.)

### [Value](../src/Core/DocCommentElementAttribute.cs#L8)
```cs
public string Value { get; }
```

The value of the attribute (e.g. the actual name in `name` attribute).

