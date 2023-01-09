# ThenPipe
A [`IPipe{I,O}`](./IPipe{I,O}.md)that composes two pipes together.

```cs
public class ThenPipe<I, O1, O2> : IPipe<I, O2>
```

## Methods
### Run
```cs
public async Task<O2> Run(I i)
```

