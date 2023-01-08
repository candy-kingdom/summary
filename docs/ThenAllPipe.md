# ThenAllPipe
A [`IPipe{I,O}`](./IPipe{I,O}.md)that aggregates the result of the specified pipe.

```cs
public ThenAllPipe<I, O1, O2> : IPipe<I, O2[]>
```

## Fields
### _inner
```cs
private readonly IPipe<I, O1[]> _inner
```

### _map
```cs
private readonly IPipe<O1, O2> _map
```

## Methods
### Run
```cs
public async Task<O2[]> Run(I input)
```

