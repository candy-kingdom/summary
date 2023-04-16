# Summary.DocIndexer
A [`DocProperty`](./DocProperty.md) that represents an indexer.

```cs
public record DocIndexer : DocProperty
```

## Properties
### Params
The parameters of the indexer.

```cs
public required DocParam[] Params { get; init; }
```

