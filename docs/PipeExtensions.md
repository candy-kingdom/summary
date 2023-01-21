# PipeExtensions
Extension methods for [`IPipe{I,O}`](./IPipe{I,O}.md).

```cs
public static class PipeExtensions
```

## Methods
### Run(IPipe<Unit, O>)
Asynchronously runs the pipe.

```cs
public static Task<O> Run<O>(this IPipe<Unit, O> pipe)
```

### Then(IPipe<I, O1>, IPipe<O1, O2>)
Composes the pipe with another pipe so that the output of the first pipe is passed as an input to the second pipe.

```cs
public static IPipe<I, O2> Then<I, O1, O2>(this IPipe<I, O1> a, IPipe<O1, O2> b)
```

### Then(IPipe<I, O1>, Func<O1, O2>)
Constructs a new pipe that will apply the specified `select` function to the output of the current pipe.

```cs
public static IPipe<I, O2> Then<I, O1, O2>(this IPipe<I, O1> a, Func<O1, O2> map)
```

### ThenForEach(IPipe<I, O1[]>, IPipe<O1, O2>)
Constructs a new pipe that will apply the specified map pipe to the each element of the output of the current pipe.

```cs
public static IPipe<I, O2[]> ThenForEach<I, O1, O2>(this IPipe<I, O1[]> a, IPipe<O1, O2> b)
```

### Tee(IPipe<I, O>, Action<O>)
Constructs a new pipe that will execute the specified action on the output.

```cs
public static IPipe<I, O> Tee<I, O>(this IPipe<I, O> a, Action<O> action)
```

