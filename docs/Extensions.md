# Extensions
Extension methods that simplify unit testing and should not be included in the package.

```cs
public static class Extensions
```

## Methods
### RunSync(IPipe<Unit, O>)
Runs the pipe synchronously

```cs
public static O RunSync<O>(this IPipe<Unit, O> self)
```

#### Parameters
- `self`: The pipe to execute.
### RunSync(IPipe<I, O>, I)
```cs
public static O RunSync<I, O>(this IPipe<I, O> self, I input)
```

