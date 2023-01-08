# Unit
A void type that is similar to `void` keyword.

```cs
public Unit 
```

## Fields
### Value
The only instance of the [`Unit`](./Unit.md).

```cs
public static readonly Unit Value = new()
```

### CompletedTask
The completed task instance that contains the [`Unit`](./Unit.md)value.

```cs
public static readonly Task<Unit> CompletedTask = Task.FromResult(Value)
```

