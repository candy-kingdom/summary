# [Summary.DocLocation](../src/Core/DocLocation.cs#L6)
```cs
public record DocLocation
```

The location of the documented member.

## Properties
### [Path](../src/Core/DocLocation.cs#L11)
```cs
public required string Path { get; init; }
```

The path to the file where the member is located.

### [Start](../src/Core/DocLocation.cs#L16)
```cs
public required (int Line, int? Column) Start { get; init; }
```

The location where the member starts.

### [End](../src/Core/DocLocation.cs#L21)
```cs
public (int Line, int? Column)? End { get; init; }
```

The location where the member ends.

