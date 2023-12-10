# [Summary.DocParam](../src/Core/DocParam.cs#L8)
```cs
public record DocParam(DocType? Type, string Name)
```

A parameter of a [`DocMethod`](./DocMethod.md).

## Properties
### [Type](../src/Core/DocParam.cs#L8)
```cs
public DocType? Type { get; }
```

The type of the parameter.

### [Name](../src/Core/DocParam.cs#L8)
```cs
public string Name { get; }
```

The name of the parameter.

## Methods
### [Comment(DocMember)](../src/Core/DocParam.cs#L13)
```cs
public DocCommentElement? Comment(DocMember parent)
```

The comment of the parameter (i.e., `<param>` tag).

