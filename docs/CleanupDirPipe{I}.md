# [Summary.Pipes.IO.CleanupDirPipe<I>](../src/Core/Pipes/IO/CleanupDirPipe.cs#L6)
```cs
public class CleanupDirPipe<I> : IPipe<I, I>
```

Cleans up a given directory by deleting and re-creating it.

## Methods
### [Run(I)](../src/Core/Pipes/IO/CleanupDirPipe.cs#L9)
```cs
public Task<I> Run(I input)
```

Asynchronously processes the specified input and returns the output.

