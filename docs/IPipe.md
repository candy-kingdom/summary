# IPipe
An asynchronous pipe that can transform an input to the output.

```cs
public IPipe<in I, O> 
```

## Methods
### Run
Asynchronously processes the specified input and returns the output.

```cs
 Task<O> Run(I input)
```

