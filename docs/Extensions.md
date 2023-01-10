# Extensions
Extension methods that simplify unit testing and should not be included in the package.

```cs
public static class Extensions
```

## Methods
### RunSync
Runs the pipe synchronously

```cs
public static O RunSync<O>(this IPipe<Unit, O> self)
```

#### Parameters
- `IPipe<Unit, O>`: The pipe to execute.
### RunSync
```cs
public static O RunSync<I, O>(this IPipe<I, O> self, I input)
```

