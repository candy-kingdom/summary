# [Summary.DocLocation](../src/Core/DocLocation.cs#L5)
```cs
public record DocLocation
```

The location of the documented member.

## Properties
### Path
```cs
public required string Path { get; init; }
```

The path to the file where the member is located.

### Start
```cs
public required (int Line, int? Column) Start { get; init; }
```

The location where the member starts.

### End
```cs
public (int Line, int? Column)? End { get; init; }
```

The location where the member ends.

