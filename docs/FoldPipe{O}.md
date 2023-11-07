# Summary.Pipes.FoldPipe<O>
```cs
public class FoldPipe<O> : IPipe<O[], O>
```

A [`IPipe{I,O}`](./IPipe{I,O}.md) that aggregates the result of the specified pipe.

## Methods
### Run(O[])
```cs
public Task<O> Run(O[] input)
```
