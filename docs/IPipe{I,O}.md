# [Summary.Pipes.IPipe<I, O>](../src/Core/Pipes/IPipe.cs#L8)
```cs
public interface IPipe<in I, O>
```

An asynchronous pipe that can transform an input to the output.

## Type Parameters
- `I`: The type of the input of the pipe.
- `O`: The type of the output of the pipe.

## Methods
### [Run(I)](../src/Core/Pipes/IPipe.cs#L13)
```cs
 Task<O> Run(I input)
```

Asynchronously processes the specified input and returns the output.

