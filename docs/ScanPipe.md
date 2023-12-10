# [Summary.Pipes.IO.ScanPipe](../src/Core/Pipes/IO/ScanPipe.cs#L5)
```cs
public class ScanPipe : IPipe<Unit, Source[]>
```

A [`IPipe{I,O}`](./IPipe{I,O}.md) that searches specified directory (recursively) for files that match specified pattern.

## Methods
### Run(Unit)
```cs
public async Task<Source[]> Run(Unit _)
```

