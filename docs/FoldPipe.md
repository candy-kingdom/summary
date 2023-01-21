# FoldPipe
A [`IPipe{I,O}`](./IPipe{I,O}.md) that aggregates the result of the specified pipe.

```cs
public class FoldPipe<O> : IPipe<O[], O>
```

## Methods
### Run(O[])
```cs
public Task<O> Run(O[] input)
```

