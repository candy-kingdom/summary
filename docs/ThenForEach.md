# ThenForEach
A [`IPipe{I,O}`](./IPipe{I,O}.md)that aggregates the result of the specified pipe.

```cs
public class ThenForEach<I, O1, O2> : IPipe<I, O2[]>
```

## Methods
### Run
```cs
public async Task<O2[]> Run(I input)
```

