# [Summary.DocTypeParam](../src/Core/DocTypeParam.cs#L6)
```cs
public record DocTypeParam(string Name)
```

A type parameter of a [`DocMember`](./DocMember.md).

## Properties
### [Name](../src/Core/DocTypeParam.cs#L6)
```cs
public string Name { get; }
```

The name of the parameter.

## Methods
### [Comment(DocMember)](../src/Core/DocTypeParam.cs#L11)
```cs
public DocCommentElement? Comment(DocMember parent)
```

The comment of the parameter (i.e., `<typeparam>` tag).

