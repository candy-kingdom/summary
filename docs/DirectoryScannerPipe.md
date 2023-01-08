# DirectoryScannerPipe
A [`IPipe{I,O}`](./IPipe{I,O}.md)that searches specified directory (recursively) for files that match specified pattern.

```cs
public DirectoryScannerPipe : IPipe<Unit, string[]>
```

## Fields
### _root
```cs
private readonly string _root
```

### _pattern
```cs
private readonly string _pattern
```

## Methods
### Run
```cs
public async Task<string[]> Run(Unit _)
```

