# FlattenPipe
A [`IPipe{I,O}`](./IPipe{I,O}.md)that aggregates the result of the specified pipe.

```cs
public FlattenPipe<O> : IPipe<O[], O>
```

## Methods
### Run
```cs
public Task<O> Run(O[] input)
```

