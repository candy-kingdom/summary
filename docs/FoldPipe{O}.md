# [Summary.Pipes.FoldPipe<O>](../src/Core/Pipes/FoldPipe.cs#L6)
```cs
public class FoldPipe<O> : IPipe<O[], O>
```

A [`IPipe{I,O}`](./IPipe{I,O}.md) that aggregates the result of the specified pipe.

## Methods
### [Run(O[])](../src/Core/Pipes/FoldPipe.cs#L8)
```cs
public Task<O> Run(O[] input)
```

