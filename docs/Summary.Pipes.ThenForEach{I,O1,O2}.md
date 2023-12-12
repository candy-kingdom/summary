# [Summary.Pipes.ThenForEach<I, O1, O2>](../src/Core/Pipes/ThenForEach.cs#L6)
```cs
public class ThenForEach<I, O1, O2> : IPipe<I, O2[]>
```

A [`IPipe{I,O}`](./Summary.Pipes.IPipe{I,O}.md) that aggregates the result of the specified pipe.

## Methods
### [Run(I)](../src/Core/Pipes/ThenForEach.cs#L9)
```cs
public async Task<O2[]> Run(I input)
```

Asynchronously processes the specified input and returns the output.

