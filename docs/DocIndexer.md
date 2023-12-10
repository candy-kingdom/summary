# [Summary.DocIndexer](../src/Core/DocIndexer.cs#L6)
```cs
public record DocIndexer : DocProperty
```

A [`DocProperty`](./DocProperty.md) that represents an indexer.

## Properties
### [Params](../src/Core/DocIndexer.cs#L11)
```cs
public required DocParam[] Params { get; init; }
```

The parameters of the indexer.

