# [Summary.Pipes.FuncPipe<I, O>](../src/Core/Pipes/FuncPipe.cs#L6)
```cs
public class FuncPipe<I, O> : IPipe<I, O>
```

A [`IPipe{I,O}`](./Summary.Pipes.IPipe{I,O}.md) that wraps <u>`Func{I,O}`</u>.

## Methods
### [Run(I)](../src/Core/Pipes/FuncPipe.cs#L21)
```cs
public Task<O> Run(I input)
```

Asynchronously processes the specified input and returns the output.

