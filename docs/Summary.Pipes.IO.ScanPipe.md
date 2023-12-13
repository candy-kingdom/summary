# [Summary.Pipes.IO.ScanPipe](../src/Core/Pipes/IO/ScanPipe.cs#L6)
```cs
public class ScanPipe : IPipe<Unit, Source[]>
```

A [`IPipe<I, O>`](./Summary.Pipes.IPipe{I,O}.md) that searches specified directory (recursively) for files that match specified pattern.

## Methods
### [Run(Unit)](../src/Core/Pipes/IO/ScanPipe.cs#L9)
```cs
public async Task<Source[]> Run(Unit _)
```

Asynchronously processes the specified input and returns the output.

