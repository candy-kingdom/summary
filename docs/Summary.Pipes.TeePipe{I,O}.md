# [Summary.Pipes.TeePipe&lt;I, O&gt;](../src/Core/Pipes/TeePipe.cs#L6)
```cs
public class TeePipe<I, O> : IPipe<I, O>
```

A [`IPipe<I, O>`](./Summary.Pipes.IPipe{I,O}.md) that invokes an action on the output of the pipe each time it's executed.

## Methods
### [Run(I)](../src/Core/Pipes/TeePipe.cs#L9)
```cs
public async Task<O> Run(I input)
```

Asynchronously processes the specified input and returns the output.

