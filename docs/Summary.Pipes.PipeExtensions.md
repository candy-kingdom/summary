# [Summary.Pipes.PipeExtensions](../src/Core/Pipes/PipeExtensions.cs#L9)
```cs
public static class PipeExtensions
```

Extension methods for [`IPipe&lt;I, O&gt;`](./Summary.Pipes.IPipe{I,O}.md).

## Methods
### [Fold&lt;I&gt;(IPipe&lt;I, Unit[]&gt;)](../src/Core/Pipes/PipeExtensions.cs#L14)
```cs
public static IPipe&lt;I, Unit&gt; Fold&lt;I&gt;(this IPipe&lt;I, Unit[]&gt; self)
```

Folds the result of the specified pipe into a single [`Unit`](./Summary.Pipes.Unit.md) value.

### [Run&lt;O&gt;(IPipe&lt;Unit, O&gt;)](../src/Core/Pipes/PipeExtensions.cs#L20)
```cs
public static Task&lt;O&gt; Run&lt;O&gt;(this IPipe&lt;Unit, O&gt; self)
```

Asynchronously runs the pipe.

### [Then&lt;I, O1, O2&gt;(IPipe&lt;I, O1&gt;, IPipe&lt;O1, O2&gt;)](../src/Core/Pipes/PipeExtensions.cs#L26)
```cs
public static IPipe&lt;I, O2&gt; Then&lt;I, O1, O2&gt;(this IPipe&lt;I, O1&gt; a, IPipe&lt;O1, O2&gt; b)
```

Composes the pipe with another pipe so that the output of the first pipe is passed as an input to the second pipe.

### [Then&lt;I, O&gt;(IPipe&lt;I, O&gt;, IPipe&lt;O, O&gt;, bool)](../src/Core/Pipes/PipeExtensions.cs#L32)
```cs
public static IPipe&lt;I, O&gt; Then&lt;I, O&gt;(this IPipe&lt;I, O&gt; a, IPipe&lt;O, O&gt; b, bool when)
```

Composes the pipe with another pipe so that the output of the first pipe is passed as an input to the second pipe.

### [Then&lt;I, O1, O2&gt;(IPipe&lt;I, O1&gt;, Func&lt;O1, O2&gt;)](../src/Core/Pipes/PipeExtensions.cs#L38)
```cs
public static IPipe&lt;I, O2&gt; Then&lt;I, O1, O2&gt;(this IPipe&lt;I, O1&gt; a, Func&lt;O1, O2&gt; map)
```

Constructs a new pipe that will apply the specified `select` function to the output of the current pipe.

### [Then&lt;I, O&gt;(IPipe&lt;I, O&gt;, Func&lt;O, O&gt;, bool)](../src/Core/Pipes/PipeExtensions.cs#L44)
```cs
public static IPipe&lt;I, O&gt; Then&lt;I, O&gt;(this IPipe&lt;I, O&gt; a, Func&lt;O, O&gt; map, bool when)
```

Constructs a new pipe that will apply the specified `select` function to the output of the current pipe.

### [ThenForEach&lt;I, O1, O2&gt;(IPipe&lt;I, O1[]&gt;, IPipe&lt;O1, O2&gt;)](../src/Core/Pipes/PipeExtensions.cs#L50)
```cs
public static IPipe&lt;I, O2[]&gt; ThenForEach&lt;I, O1, O2&gt;(this IPipe&lt;I, O1[]&gt; a, IPipe&lt;O1, O2&gt; b)
```

Constructs a new pipe that will apply the specified map pipe to the each element of the output of the current pipe.

### [Tee&lt;I, O&gt;(IPipe&lt;I, O&gt;, Action&lt;O&gt;)](../src/Core/Pipes/PipeExtensions.cs#L56)
```cs
public static IPipe&lt;I, O&gt; Tee&lt;I, O&gt;(this IPipe&lt;I, O&gt; a, Action&lt;O&gt; action)
```

Constructs a new pipe that will execute the specified action on the output.

### [Logged&lt;I, O&gt;(IPipe&lt;I, O&gt;, ILoggerFactory, string)](../src/Core/Pipes/PipeExtensions.cs#L62)
```cs
public static IPipe&lt;I, O&gt; Logged&lt;I, O&gt;(this IPipe&lt;I, O&gt; self, ILoggerFactory factory, string message)
```

Logs the execution of the given pipe using the specified logger factory.

### [Logged&lt;I, O&gt;(IPipe&lt;I, O&gt;, ILoggerFactory, Func&lt;I, string&gt;)](../src/Core/Pipes/PipeExtensions.cs#L66)
```cs
public static IPipe&lt;I, O&gt; Logged&lt;I, O&gt;(this IPipe&lt;I, O&gt; self, ILoggerFactory factory, Func&lt;I, string&gt; message)
```

Logs the execution of the given pipe using the specified logger factory.

### [Logged&lt;I, O&gt;(IPipe&lt;I, O&gt;, ILogger, string)](../src/Core/Pipes/PipeExtensions.cs#L72)
```cs
public static IPipe&lt;I, O&gt; Logged&lt;I, O&gt;(this IPipe&lt;I, O&gt; self, ILogger logger, string message)
```

Logs the execution of the given pipe using the specified logger.

### [Logged&lt;I, O&gt;(IPipe&lt;I, O&gt;, ILogger, Func&lt;I, string&gt;)](../src/Core/Pipes/PipeExtensions.cs#L76)
```cs
public static IPipe&lt;I, O&gt; Logged&lt;I, O&gt;(this IPipe&lt;I, O&gt; self, ILogger logger, Func&lt;I, string&gt; message)
```

Logs the execution of the given pipe using the specified logger.

