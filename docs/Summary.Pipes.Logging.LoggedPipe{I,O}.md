# [Summary.Pipes.Logging.LoggedPipe<I, O>](../src/Core/Pipes/Logging/LoggedPipe.cs#L11)
```cs
public class LoggedPipe<I, O> : IPipe<I, O>
```

A [`IPipe{I,O}`](./Summary.Pipes.IPipe{I,O}.md) whose output is logged using the provided logger.

_Logging is implemented by simply beginning a new scope with the given message._

## Methods
### [Run(I)](../src/Core/Pipes/Logging/LoggedPipe.cs#L20)
```cs
public Task<O> Run(I input)
```

Asynchronously processes the specified input and returns the output.

