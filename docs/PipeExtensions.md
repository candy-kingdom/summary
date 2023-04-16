# Summary.Pipes.PipeExtensions
```cs
public static class PipeExtensions
```

Extension methods for [`IPipe{I,O}`](./IPipe{I,O}.md).

## Methods
### Fold<I>(IPipe<I, Unit[]>)
```cs
public static IPipe<I, Unit> Fold<I>(this IPipe<I, Unit[]> self)
```

Folds the result of the specified pipe into a single [`Unit`](./Unit.md) value.

### Run<O>(IPipe<Unit, O>)
```cs
public static Task<O> Run<O>(this IPipe<Unit, O> self)
```

Asynchronously runs the pipe.

### Then<I, O1, O2>(IPipe<I, O1>, IPipe<O1, O2>)
```cs
public static IPipe<I, O2> Then<I, O1, O2>(this IPipe<I, O1> a, IPipe<O1, O2> b)
```

Composes the pipe with another pipe so that the output of the first pipe is passed as an input to the second pipe.

### Then<I, O1, O2>(IPipe<I, O1>, Func<O1, O2>)
```cs
public static IPipe<I, O2> Then<I, O1, O2>(this IPipe<I, O1> a, Func<O1, O2> map)
```

Constructs a new pipe that will apply the specified `select` function to the output of the current pipe.

### ThenForEach<I, O1, O2>(IPipe<I, O1[]>, IPipe<O1, O2>)
```cs
public static IPipe<I, O2[]> ThenForEach<I, O1, O2>(this IPipe<I, O1[]> a, IPipe<O1, O2> b)
```

Constructs a new pipe that will apply the specified map pipe to the each element of the output of the current pipe.

### Tee<I, O>(IPipe<I, O>, Action<O>)
```cs
public static IPipe<I, O> Tee<I, O>(this IPipe<I, O> a, Action<O> action)
```

Constructs a new pipe that will execute the specified action on the output.

