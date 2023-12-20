# [Summary.Pipes.PipeExtensions](../src/Core/Pipes/PipeExtensions.cs#L9)
```cs
public static class PipeExtensions
```

Extension methods for [`IPipe<I, O>`](./Summary.Pipes.IPipe{I,O}.md).

## Methods
### [Fold&lt;I&gt;(IPipe&lt;I, Unit[]&gt;)](../src/Core/Pipes/PipeExtensions.cs#L14)
```cs
public static IPipe<I, Unit> Fold<I>(this IPipe<I, Unit[]> self)
```

Folds the result of the specified pipe into a single [`Unit`](./Summary.Pipes.Unit.md) value.

### [Run&lt;O&gt;(IPipe&lt;Unit, O&gt;)](../src/Core/Pipes/PipeExtensions.cs#L20)
```cs
public static Task<O> Run<O>(this IPipe<Unit, O> self)
```

Asynchronously runs the pipe.

### [Then&lt;I, O1, O2&gt;(IPipe&lt;I, O1&gt;, IPipe&lt;O1, O2&gt;)](../src/Core/Pipes/PipeExtensions.cs#L26)
```cs
public static IPipe<I, O2> Then<I, O1, O2>(this IPipe<I, O1> a, IPipe<O1, O2> b)
```

Composes the pipe with another pipe so that the output of the first pipe is passed as an input to the second pipe.

### [Then&lt;I, O&gt;(IPipe&lt;I, O&gt;, IPipe&lt;O, O&gt;, bool)](../src/Core/Pipes/PipeExtensions.cs#L32)
```cs
public static IPipe<I, O> Then<I, O>(this IPipe<I, O> a, IPipe<O, O> b, bool when)
```

Composes the pipe with another pipe so that the output of the first pipe is passed as an input to the second pipe.

### [Then&lt;I, O1, O2&gt;(IPipe&lt;I, O1&gt;, Func&lt;O1, O2&gt;)](../src/Core/Pipes/PipeExtensions.cs#L38)
```cs
public static IPipe<I, O2> Then<I, O1, O2>(this IPipe<I, O1> a, Func<O1, O2> map)
```

Constructs a new pipe that will apply the specified `select` function to the output of the current pipe.

### [Then&lt;I, O&gt;(IPipe&lt;I, O&gt;, Func&lt;O, O&gt;, bool)](../src/Core/Pipes/PipeExtensions.cs#L44)
```cs
public static IPipe<I, O> Then<I, O>(this IPipe<I, O> a, Func<O, O> map, bool when)
```

Constructs a new pipe that will apply the specified `select` function to the output of the current pipe.

### [ThenForEach&lt;I, O1, O2&gt;(IPipe&lt;I, O1[]&gt;, IPipe&lt;O1, O2&gt;)](../src/Core/Pipes/PipeExtensions.cs#L50)
```cs
public static IPipe<I, O2[]> ThenForEach<I, O1, O2>(this IPipe<I, O1[]> a, IPipe<O1, O2> b)
```

Constructs a new pipe that will apply the specified map pipe to the each element of the output of the current pipe.

### [Tee&lt;I, O&gt;(IPipe&lt;I, O&gt;, Action&lt;O&gt;)](../src/Core/Pipes/PipeExtensions.cs#L56)
```cs
public static IPipe<I, O> Tee<I, O>(this IPipe<I, O> a, Action<O> action)
```

Constructs a new pipe that will execute the specified action on the output.

### [Logged&lt;I, O&gt;(IPipe&lt;I, O&gt;, ILoggerFactory, string)](../src/Core/Pipes/PipeExtensions.cs#L62)
```cs
public static IPipe<I, O> Logged<I, O>(this IPipe<I, O> self, ILoggerFactory factory, string message)
```

Logs the execution of the given pipe using the specified logger factory.

### [Logged&lt;I, O&gt;(IPipe&lt;I, O&gt;, ILoggerFactory, Func&lt;I, string&gt;)](../src/Core/Pipes/PipeExtensions.cs#L66)
```cs
public static IPipe<I, O> Logged<I, O>(this IPipe<I, O> self, ILoggerFactory factory, Func<I, string> message)
```

Logs the execution of the given pipe using the specified logger factory.

### [Logged&lt;I, O&gt;(IPipe&lt;I, O&gt;, ILogger, string)](../src/Core/Pipes/PipeExtensions.cs#L72)
```cs
public static IPipe<I, O> Logged<I, O>(this IPipe<I, O> self, ILogger logger, string message)
```

Logs the execution of the given pipe using the specified logger.

### [Logged&lt;I, O&gt;(IPipe&lt;I, O&gt;, ILogger, Func&lt;I, string&gt;)](../src/Core/Pipes/PipeExtensions.cs#L76)
```cs
public static IPipe<I, O> Logged<I, O>(this IPipe<I, O> self, ILogger logger, Func<I, string> message)
```

Logs the execution of the given pipe using the specified logger.

