# [Summary.Pipes.FuncPipe&lt;I, O&gt;](../src/Core/Pipes/FuncPipe.cs#L6)
```cs
public class FuncPipe&lt;I, O&gt; : IPipe&lt;I, O&gt;
```

A [`IPipe&lt;I, O&gt;`](./Summary.Pipes.IPipe{I,O}.md) that wraps &lt;u&gt;`Func&lt;I, O&gt;`&lt;/u&gt;.

## Methods
### [Run(I)](../src/Core/Pipes/FuncPipe.cs#L21)
```cs
public Task&lt;O&gt; Run(I input)
```

Asynchronously processes the specified input and returns the output.

