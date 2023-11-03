# Summary.Pipes.FuncPipe
```cs
public class FuncPipe<I, O> : IPipe<I, O>
```

A [`IPipe{I,O}`](./IPipe{I,O}.md) that wraps [`Func{I,O}`](./Func{I,O}.md).

## Methods
### Run(I)
```cs
public Task<O> Run(I input)
```

