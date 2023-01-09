# PipeExtensions
Extension methods for [`IPipe{I,O}`](./IPipe{I,O}.md).

```cs
public static class PipeExtensions
```

## Methods
### Run
Asynchronously runs the pipe.

```cs
public static Task<O> Run<O>(this IPipe<Unit, O> pipe)
```

### Then
Composes the pipe with another pipe so that the output of the first pipe is passed as an input to the second pipe.

```cs
public static IPipe<I, O2> Then<I, O1, O2>(this IPipe<I, O1> a, IPipe<O1, O2> b)
```

### Then
Constructs a new pipe that will apply the specified `select` function to the output of the current pipe.

```cs
public static IPipe<I, O2> Then<I, O1, O2>(this IPipe<I, O1> a, Func<O1, O2> map)
```

### ThenForEach
Constructs a new pipe that will apply the specified map pipe to the each element of the output of the current pipe.

```cs
public static IPipe<I, O2[]> ThenForEach<I, O1, O2>(this IPipe<I, O1[]> a, IPipe<O1, O2> b)
```

### Tee
Constructs a new pipe that will execute the specified action on the output.

```cs
public static IPipe<I, O> Tee<I, O>(this IPipe<I, O> a, Action<O> action)
```

