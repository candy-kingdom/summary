# [Summary.Pipes.FuncPipe<I, O>](../src/Core/Pipes/FuncPipe.cs#L6)
```cs
public class FuncPipe<I, O> : IPipe<I, O>
```

A [`IPipe{I,O}`](./IPipe{I,O}.md) that wraps [`Func{I,O}`](./Func{I,O}.md).

## Methods
### [Run(I)](../src/Core/Pipes/FuncPipe.cs#L21)
```cs
public Task<O> Run(I input)
```

Asynchronously processes the specified input and returns the output.

