# [Summary.DocLocation](../src/Core/DocLocation.cs#L5)
```cs
public record DocLocation
```

The location of the documented member.

## Properties
### [Path](../src/Core/DocLocation.cs#L10)
```cs
public required string Path { get; init; }
```

The path to the file where the member is located.

### [Start](../src/Core/DocLocation.cs#L15)
```cs
public required (int Line, int? Column) Start { get; init; }
```

The location where the member starts.

### [End](../src/Core/DocLocation.cs#L20)
```cs
public (int Line, int? Column)? End { get; init; }
```

The location where the member ends.

