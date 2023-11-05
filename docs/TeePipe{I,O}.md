# Summary.Pipes.TeePipe<I, O>
```cs
public class TeePipe<I, O> : IPipe<I, O>
```

A [`IPipe{I,O}`](./IPipe{I,O}.md) that invokes an action on the output of the pipe each time it's executed.

## Methods
### Run(I)
```cs
public async Task<O> Run(I input)
```

