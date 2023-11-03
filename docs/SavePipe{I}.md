# Summary.Pipes.IO.SavePipe
```cs
public class SavePipe<I> : IPipe<I, Unit>
```

A [`IPipe{I,O}`](./IPipe{I,O}.md) that saves the input to the file.

## Methods
### Run(I)
```cs
public async Task<Unit> Run(I input)
```

