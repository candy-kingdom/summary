# [Summary.Pipes.ThenForEach<I, O1, O2>](../src/Core/Pipes/ThenForEach.cs#L5)
```cs
public class ThenForEach<I, O1, O2> : IPipe<I, O2[]>
```

A [`IPipe{I,O}`](./IPipe{I,O}.md) that aggregates the result of the specified pipe.

## Methods
### [Run(I)](../src/Core/Pipes/ThenForEach.cs#L7)
```cs
public async Task<O2[]> Run(I input)
```

