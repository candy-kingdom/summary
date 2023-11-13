# Summary.Pipes.Logging.LoggedPipe<I, O>
```cs
public class LoggedPipe<I, O> : IPipe<I, O>
```

A [`IPipe{I,O}`](./IPipe{I,O}.md) whose output is logged using the provided logger.

_Logging is implemented by simply beginning a new scope with the given message._

## Methods
### Run(I)
```cs
public Task<O> Run(I input)
```

