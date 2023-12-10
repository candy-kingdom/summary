# [Summary.Tests.Extensions](../src/Tests/Extensions.cs#L7)
```cs
public static class Extensions
```

Extension methods that simplify unit testing and should not be included in the package.

## Methods
### RunSync<O>(IPipe<Unit, O>)
```cs
public static O RunSync<O>(this IPipe<Unit, O> self)
```

Runs the pipe synchronously.

#### Parameters
- `self`: The pipe to execute.

### RunSync<I, O>(IPipe<I, O>, I)
```cs
public static O RunSync<I, O>(this IPipe<I, O> self, I input)
```

