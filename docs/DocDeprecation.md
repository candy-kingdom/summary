# Summary.DocDeprecation
```cs
public record DocDeprecation
```

Contains deprecation information (e.g. the warning message).

## Properties
### Message
```cs
public string? Message { get; init; }
```

The deprecation warning message.

### Error
```cs
public bool Error { get; init; }
```

Whether the usage should be treated as an error instead of a warning.

