# FuncPipe
A [`IPipe{I,O}`](./IPipe{I,O}.md)that wraps [`Func{I,O}`](./Func{I,O}.md).

```cs
public FuncPipe<I, O> : IPipe<I, O>
```

## Fields
### _func
```cs
private readonly Func<I, Task<O>> _func
```

## Methods
### Run
```cs
public Task<O> Run(I input)
```

