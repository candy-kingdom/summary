# [Summary.Pipes.ThenPipe&lt;I, O1, O2&gt;](../src/Core/Pipes/ThenPipe.cs#L6)
```cs
public class ThenPipe&lt;I, O1, O2&gt; : IPipe&lt;I, O2&gt;
```

A [`IPipe&lt;I, O&gt;`](./Summary.Pipes.IPipe{I,O}.md) that composes two pipes together.

## Methods
### [Run(I)](../src/Core/Pipes/ThenPipe.cs#L9)
```cs
public async Task&lt;O2&gt; Run(I i)
```

Asynchronously processes the specified input and returns the output.

