# DirectoryScannerPipe
A [`IPipe{I,O}`](./IPipe{I,O}.md)that searches specified directory (recursively) for files that match specified pattern.

```cs
public DirectoryScannerPipe : IPipe<Unit, string[]>
```

## Methods
### Run
```cs
public async Task<string[]> Run(Unit _)
```

