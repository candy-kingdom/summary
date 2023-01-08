# FlattenPipe
A [`IPipe{I,O}`](./IPipe{I,O}.md)that aggregates the result of the specified pipe.

```cs
public FlattenPipe<I, O> : IPipe<I, O>
```

## Fields
### _inner
```cs
private readonly IPipe<I, O[]> _inner
```

### _merge
```cs
private readonly Func<O, O, O> _merge
```

## Methods
### Run
```cs
public async Task<O> Run(I input)
```

