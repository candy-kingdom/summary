# [Summary.Tests.Extensions](../src/Tests/Extensions.cs#L8)
```cs
public static class Extensions
```

Extension methods that simplify unit testing and should not be included in the package.

## Methods
### [RunSync&lt;O&gt;(IPipe&lt;Unit, O&gt;)](../src/Tests/Extensions.cs#L14)
```cs
public static O RunSync&lt;O&gt;(this IPipe&lt;Unit, O&gt; self)
```

Runs the pipe synchronously.

#### Parameters
- `self`: The pipe to execute.

### [RunSync&lt;I, O&gt;(IPipe&lt;I, O&gt;, I)](../src/Tests/Extensions.cs#L18)
```cs
public static O RunSync&lt;I, O&gt;(this IPipe&lt;I, O&gt; self, I input)
```

Runs the pipe synchronously.

#### Parameters
- `self`: The pipe to execute.

