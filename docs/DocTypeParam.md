# DocTypeParam
A type parameter of a [`DocMember`](./DocMember.md).

```cs
public record DocTypeParam(string Name, DocComment Comment)
```

## Properties
### Name
The name of the parameter.

```cs
public string Name { get; }
```

### Comment
The comment of the parameter (i.e. `<typeparam>` tag).

```cs
public DocComment Comment { get; }
```

