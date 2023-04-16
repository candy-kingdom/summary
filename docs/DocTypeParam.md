# Summary.DocTypeParam
A type parameter of a [`DocMember`](./DocMember.md).

```cs
public record DocTypeParam(string Name)
```

## Properties
### Name
The name of the parameter.

```cs
public string Name { get; }
```

## Methods
### Comment(DocMember)
The comment of the parameter (i.e., `<typeparam>` tag).

```cs
public DocCommentElement? Comment(DocMember parent)
```

