# [Summary.Pipes.Logging.LoggedPipe<I, O>](../src/Core/Pipes/Logging/LoggedPipe.cs#L10)
```cs
public class LoggedPipe<I, O> : IPipe<I, O>
```

A [`IPipe{I,O}`](./IPipe{I,O}.md) whose output is logged using the provided logger.

_Logging is implemented by simply beginning a new scope with the given message._

## Methods
### [Run(I)](../src/Core/Pipes/Logging/LoggedPipe.cs#L15)
```cs
public Task<O> Run(I input)
```

