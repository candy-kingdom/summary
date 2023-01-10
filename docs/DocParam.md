# DocParam
A parameter of a [`DocMethod`](./DocMethod.md).

```cs
public record DocParam(string Type, string Name, DocComment Comment)
```

## Properties
### Type
The type of the parameter.

```cs
 string Type { get; }
```

### Name
The name of the parameter.

```cs
 string Name { get; }
```

### Comment
The comment of the parameter (i.e. `<param>` tag).

```cs
 DocComment Comment { get; }
```

