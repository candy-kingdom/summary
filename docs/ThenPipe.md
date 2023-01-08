# ThenPipe
A [`IPipe{I,O}`](./IPipe{I,O}.md)that composes two pipes together.

```cs
public ThenPipe<I, O1, O2> : IPipe<I, O2>
```

## Fields
### _a
```cs
private readonly IPipe<I, O1> _a
```

### _b
```cs
private readonly IPipe<O1, O2> _b
```

## Methods
### Run
```cs
public async Task<O2> Run(I i)
```

