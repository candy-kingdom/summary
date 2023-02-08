# DocParam
A parameter of a [`DocMethod`](./DocMethod.md).

```cs
public record DocParam(DocType? Type, string Name, DocComment Comment)
```

## Properties
### Type
The type of the parameter.

```cs
public DocType? Type { get; }
```

### Name
The name of the parameter.

```cs
public string Name { get; }
```

### Comment
The comment of the parameter (i.e. `<param>` tag).

```cs
public DocComment Comment { get; }
```

