# [Summary.Pipes.IO.SavePipe<I>](../src/Core/Pipes/IO/SavePipe.cs#L6)
```cs
public class SavePipe<I> : IPipe<I, Unit>
```

A [`IPipe{I,O}`](./IPipe{I,O}.md) that saves the input to the file.

## Methods
### [Run(I)](../src/Core/Pipes/IO/SavePipe.cs#L8)
```cs
public async Task<Unit> Run(I input)
```

