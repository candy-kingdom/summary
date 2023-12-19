# [Summary.Pipes.FoldPipe&lt;O&gt;](../src/Core/Pipes/FoldPipe.cs#L6)
```cs
public class FoldPipe&lt;O&gt; : IPipe&lt;O[], O&gt;
```

A [`IPipe&lt;I, O&gt;`](./Summary.Pipes.IPipe{I,O}.md) that aggregates the result of the specified pipe.

## Methods
### [Run(O[])](../src/Core/Pipes/FoldPipe.cs#L9)
```cs
public Task&lt;O&gt; Run(O[] input)
```

Asynchronously processes the specified input and returns the output.

