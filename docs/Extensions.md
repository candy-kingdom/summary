# [Summary.Tests.Extensions](../src/Tests/Extensions.cs#L8)
```cs
public static class Extensions
```

Extension methods that simplify unit testing and should not be included in the package.

## Methods
### [RunSync<O>(IPipe<Unit, O>)](../src/Tests/Extensions.cs#L14)
```cs
public static O RunSync<O>(this IPipe<Unit, O> self)
```

Runs the pipe synchronously.

#### Parameters
- `self`: The pipe to execute.

### [RunSync<I, O>(IPipe<I, O>, I)](../src/Tests/Extensions.cs#L18)
```cs
public static O RunSync<I, O>(this IPipe<I, O> self, I input)
```

