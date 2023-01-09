# FuncPipe
A [`IPipe{I,O}`](./IPipe{I,O}.md) that wraps [`Func{I,O}`](./Func{I,O}.md).

```cs
public class FuncPipe<I, O> : IPipe<I, O>
```

## Methods
### Run
```cs
public Task<O> Run(I input)
```

