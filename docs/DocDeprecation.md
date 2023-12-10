# [Summary.DocDeprecation](../src/Core/DocDeprecation.cs#L6)
```cs
public record DocDeprecation
```

Contains deprecation information (e.g. the warning message).

## Properties
### [Message](../src/Core/DocDeprecation.cs#L11)
```cs
public string? Message { get; init; }
```

The deprecation warning message.

### [Error](../src/Core/DocDeprecation.cs#L16)
```cs
public bool Error { get; init; }
```

Whether the usage should be treated as an error instead of a warning.

