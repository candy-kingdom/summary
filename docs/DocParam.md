# Summary.DocParam
```cs
public record DocParam(DocType? Type, string Name)
```

A parameter of a [`DocMethod`](./DocMethod.md).

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

## Methods
### Comment(DocMember)
```cs
public DocCommentElement? Comment(DocMember parent)
```

The comment of the parameter (i.e., `<param>` tag).

