# [Summary.Pipes.PipeExtensions](../src/Core/Pipes/PipeExtensions.cs#L9)
```cs
public static class PipeExtensions
```

Extension methods for [`IPipe{I,O}`](./IPipe{I,O}.md).

## Methods
### [Fold<I>(IPipe<I, Unit[]>)](../src/Core/Pipes/PipeExtensions.cs#L14)
```cs
public static IPipe<I, Unit> Fold<I>(this IPipe<I, Unit[]> self)
```

Folds the result of the specified pipe into a single [`Unit`](./Unit.md) value.

### [Run<O>(IPipe<Unit, O>)](../src/Core/Pipes/PipeExtensions.cs#L20)
```cs
public static Task<O> Run<O>(this IPipe<Unit, O> self)
```

Asynchronously runs the pipe.

### [Then<I, O1, O2>(IPipe<I, O1>, IPipe<O1, O2>)](../src/Core/Pipes/PipeExtensions.cs#L26)
```cs
public static IPipe<I, O2> Then<I, O1, O2>(this IPipe<I, O1> a, IPipe<O1, O2> b)
```

Composes the pipe with another pipe so that the output of the first pipe is passed as an input to the second pipe.

### [Then<I, O>(IPipe<I, O>, IPipe<O, O>, bool)](../src/Core/Pipes/PipeExtensions.cs#L32)
```cs
public static IPipe<I, O> Then<I, O>(this IPipe<I, O> a, IPipe<O, O> b, bool when)
```

Composes the pipe with another pipe so that the output of the first pipe is passed as an input to the second pipe.

### [Then<I, O1, O2>(IPipe<I, O1>, Func<O1, O2>)](../src/Core/Pipes/PipeExtensions.cs#L38)
```cs
public static IPipe<I, O2> Then<I, O1, O2>(this IPipe<I, O1> a, Func<O1, O2> map)
```

Constructs a new pipe that will apply the specified `select` function to the output of the current pipe.

### [Then<I, O>(IPipe<I, O>, Func<O, O>, bool)](../src/Core/Pipes/PipeExtensions.cs#L44)
```cs
public static IPipe<I, O> Then<I, O>(this IPipe<I, O> a, Func<O, O> map, bool when)
```

Constructs a new pipe that will apply the specified `select` function to the output of the current pipe.

### [ThenForEach<I, O1, O2>(IPipe<I, O1[]>, IPipe<O1, O2>)](../src/Core/Pipes/PipeExtensions.cs#L50)
```cs
public static IPipe<I, O2[]> ThenForEach<I, O1, O2>(this IPipe<I, O1[]> a, IPipe<O1, O2> b)
```

Constructs a new pipe that will apply the specified map pipe to the each element of the output of the current pipe.

### [Tee<I, O>(IPipe<I, O>, Action<O>)](../src/Core/Pipes/PipeExtensions.cs#L56)
```cs
public static IPipe<I, O> Tee<I, O>(this IPipe<I, O> a, Action<O> action)
```

Constructs a new pipe that will execute the specified action on the output.

### [Logged<I, O>(IPipe<I, O>, ILoggerFactory, string)](../src/Core/Pipes/PipeExtensions.cs#L62)
```cs
public static IPipe<I, O> Logged<I, O>(this IPipe<I, O> self, ILoggerFactory factory, string message)
```

Logs the execution of the given pipe using the specified logger factory.

### [Logged<I, O>(IPipe<I, O>, ILoggerFactory, Func<I, string>)](../src/Core/Pipes/PipeExtensions.cs#L66)
```cs
public static IPipe<I, O> Logged<I, O>(this IPipe<I, O> self, ILoggerFactory factory, Func<I, string> message)
```

### [Logged<I, O>(IPipe<I, O>, ILogger, string)](../src/Core/Pipes/PipeExtensions.cs#L72)
```cs
public static IPipe<I, O> Logged<I, O>(this IPipe<I, O> self, ILogger logger, string message)
```

Logs the execution of the given pipe using the specified logger.

### [Logged<I, O>(IPipe<I, O>, ILogger, Func<I, string>)](../src/Core/Pipes/PipeExtensions.cs#L76)
```cs
public static IPipe<I, O> Logged<I, O>(this IPipe<I, O> self, ILogger logger, Func<I, string> message)
```

