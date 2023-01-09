# SavePipe
A [`IPipe{I,O}`](./IPipe{I,O}.md) that saves the input to the file.

```cs
public class SavePipe<I> : IPipe<I, Unit>
```

## Methods
### Run
```cs
public async Task<Unit> Run(I input)
```

