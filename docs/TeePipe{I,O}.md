# [Summary.Pipes.TeePipe<I, O>](../src/Core/Pipes/TeePipe.cs#L6)
```cs
public class TeePipe<I, O> : IPipe<I, O>
```

A [`IPipe{I,O}`](./IPipe{I,O}.md) that invokes an action on the output of the pipe each time it's executed.

## Methods
### [Run(I)](../src/Core/Pipes/TeePipe.cs#L8)
```cs
public async Task<O> Run(I input)
```

