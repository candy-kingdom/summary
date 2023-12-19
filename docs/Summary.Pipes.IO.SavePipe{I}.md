# [Summary.Pipes.IO.SavePipe&lt;I&gt;](../src/Core/Pipes/IO/SavePipe.cs#L6)
```cs
public class SavePipe&lt;I&gt; : IPipe&lt;I, Unit&gt;
```

A [`IPipe&lt;I, O&gt;`](./Summary.Pipes.IPipe{I,O}.md) that saves the input to the file.

## Methods
### [Run(I)](../src/Core/Pipes/IO/SavePipe.cs#L9)
```cs
public async Task&lt;Unit&gt; Run(I input)
```

Asynchronously processes the specified input and returns the output.

