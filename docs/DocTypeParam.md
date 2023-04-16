# Summary.DocTypeParam
```cs
public record DocTypeParam(string Name)
```

A type parameter of a [`DocMember`](./DocMember.md).

## Properties
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

The comment of the parameter (i.e., `<typeparam>` tag).

