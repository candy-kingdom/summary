# [Summary.DocIndexer](../src/Core/DocIndexer.cs#L5)
```cs
public record DocIndexer : DocProperty
```

A [`DocProperty`](./DocProperty.md) that represents an indexer.

## Properties
### [Params](../src/Core/DocIndexer.cs#L10)
```cs
public required DocParam[] Params { get; init; }
```

The parameters of the indexer.

