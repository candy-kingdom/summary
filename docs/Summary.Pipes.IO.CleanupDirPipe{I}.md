# [Summary.Pipes.IO.CleanupDirPipe&lt;I&gt;](../src/Core/Pipes/IO/CleanupDirPipe.cs#L6)
```cs
public class CleanupDirPipe&lt;I&gt; : IPipe&lt;I, I&gt;
```

Cleans up a given directory by deleting and re-creating it.

## Methods
### [Run(I)](../src/Core/Pipes/IO/CleanupDirPipe.cs#L9)
```cs
public Task&lt;I&gt; Run(I input)
```

Asynchronously processes the specified input and returns the output.

