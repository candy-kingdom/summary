# Summary.Pipes.IO.ScanPipe
```cs
public class ScanPipe : IPipe<Unit, string[]>
```

A [`IPipe{I,O}`](./IPipe{I,O}.md) that searches specified directory (recursively) for files that match specified pattern.

## Methods
### Run(Unit)
```cs
public async Task<string[]> Run(Unit _)
```

