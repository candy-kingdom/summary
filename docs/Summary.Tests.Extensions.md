# [Summary.Tests.Extensions](../src/Tests/Extensions.cs#L8)
```cs
public static class Extensions
```

Extension methods that simplify unit testing and should not be included in the package.

## Methods
### [RunSync&lt;O&gt;(IPipe&lt;Unit, O&gt;)](../src/Tests/Extensions.cs#L14)
```cs
public static O RunSync<O>(this IPipe<Unit, O> self)
```

Runs the pipe synchronously.

#### Parameters
- `self`: The pipe to execute.

### [RunSync&lt;I, O&gt;(IPipe&lt;I, O&gt;, I)](../src/Tests/Extensions.cs#L18)
```cs
public static O RunSync<I, O>(this IPipe<I, O> self, I input)
```

Runs the pipe synchronously.

#### Parameters
- `self`: The pipe to execute.

