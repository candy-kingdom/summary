# [Summary.Pipes.TeePipe&lt;I, O&gt;](../src/Core/Pipes/TeePipe.cs#L6)
```cs
public class TeePipe&lt;I, O&gt; : IPipe&lt;I, O&gt;
```

A [`IPipe&lt;I, O&gt;`](./Summary.Pipes.IPipe{I,O}.md) that invokes an action on the output of the pipe each time it's executed.

## Methods
### [Run(I)](../src/Core/Pipes/TeePipe.cs#L9)
```cs
public async Task&lt;O&gt; Run(I input)
```

Asynchronously processes the specified input and returns the output.

