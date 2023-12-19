# [Summary.Pipes.ThenForEach&lt;I, O1, O2&gt;](../src/Core/Pipes/ThenForEach.cs#L6)
```cs
public class ThenForEach&lt;I, O1, O2&gt; : IPipe&lt;I, O2[]&gt;
```

A [`IPipe&lt;I, O&gt;`](./Summary.Pipes.IPipe{I,O}.md) that aggregates the result of the specified pipe.

## Methods
### [Run(I)](../src/Core/Pipes/ThenForEach.cs#L9)
```cs
public async Task&lt;O2[]&gt; Run(I input)
```

Asynchronously processes the specified input and returns the output.

