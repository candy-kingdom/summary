# Summary.Pipes.Logging.LoggedPipe<I, O>
```cs
public class LoggedPipe<I, O> : IPipe<I, O>
```

A [`IPipe{I,O}`](./IPipe{I,O}.md) whose output is logged using the provided logger.

## Methods
### Run(I)
```cs
public Task<O> Run(I input)
```

