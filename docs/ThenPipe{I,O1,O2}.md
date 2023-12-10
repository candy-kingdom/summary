# [Summary.Pipes.ThenPipe<I, O1, O2>](../src/Core/Pipes/ThenPipe.cs#L6)
```cs
public class ThenPipe<I, O1, O2> : IPipe<I, O2>
```

A [`IPipe{I,O}`](./IPipe{I,O}.md) that composes two pipes together.

## Methods
### [Run(I)](../src/Core/Pipes/ThenPipe.cs#L9)
```cs
public async Task<O2> Run(I i)
```

Asynchronously processes the specified input and returns the output.

