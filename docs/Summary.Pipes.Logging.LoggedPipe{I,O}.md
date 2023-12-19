# [Summary.Pipes.Logging.LoggedPipe&lt;I, O&gt;](../src/Core/Pipes/Logging/LoggedPipe.cs#L11)
```cs
public class LoggedPipe&lt;I, O&gt; : IPipe&lt;I, O&gt;
```

A [`IPipe&lt;I, O&gt;`](./Summary.Pipes.IPipe{I,O}.md) whose output is logged using the provided logger.

_Logging is implemented by simply beginning a new scope with the given message._

## Methods
### [Run(I)](../src/Core/Pipes/Logging/LoggedPipe.cs#L20)
```cs
public Task&lt;O&gt; Run(I input)
```

Asynchronously processes the specified input and returns the output.

