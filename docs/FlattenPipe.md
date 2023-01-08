# FlattenPipe
A [`IPipe{I,O}`](./IPipe{I,O}.md)that aggregates the result of the specified pipe.

```cs
public FlattenPipe<I, O> : IPipe<I, O>
```

## Methods
### Run
```cs
public async Task<O> Run(I input)
```

