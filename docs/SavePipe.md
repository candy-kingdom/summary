# SavePipe
A [`IPipe{I,O}`](./IPipe{I,O}.md)that saves the input to the file.

```cs
public SavePipe<I> : IPipe<I, Unit>
```

## Fields
### _root
```cs
private readonly string _root
```

### _file
```cs
private readonly Func<I, (string Path, string Content)> _file
```

## Methods
### Run
```cs
public async Task<Unit> Run(I input)
```

