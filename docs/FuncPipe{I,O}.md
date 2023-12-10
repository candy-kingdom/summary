# [Summary.Pipes.FuncPipe<I, O>](../src/Core/Pipes/FuncPipe.cs#L5)
```cs
public class FuncPipe<I, O> : IPipe<I, O>
```

A [`IPipe{I,O}`](./IPipe{I,O}.md) that wraps [`Func{I,O}`](./Func{I,O}.md).

## Methods
### Run(I)
```cs
public Task<O> Run(I input)
```

