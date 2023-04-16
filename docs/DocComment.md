# Summary.DocComment
```cs
public record DocComment(DocCommentNode[] Nodes)
```

A documentation comment parsed from the source code.

## Fields
### Empty
```cs
public static readonly DocComment Empty
```

An empty documentation comment.

## Properties
### Nodes
```cs
public DocCommentNode[] Nodes { get; }
```

The sequence of nodes this comment consists of (e.g. `summary`, `remarks`, etc.).

## Methods
### Param(string)
```cs
public DocCommentElement? Param(string name)
```

A nested <param>documentation element that has the specified name.

#### Parameters
- `name`: The name of the parameter to search inside the comment.

### TypeParam(string)
```cs
public DocCommentElement? TypeParam(string name)
```

A nested <typeparam>documentation element that has the specified name.

#### Parameters
- `name`: The name of the parameter to search inside the comment.

### Element(string, string)
```cs
public DocCommentElement? Element(string tag, string name)
```

A nested documentation element that has the specified name (e.g. `summary`, `remarks`, etc.).

#### Parameters
- `tag`: The name of the element tag to search inside the comment.
- `name`: The value of the `name` attribute of the tag.

### Element(string)
```cs
public DocCommentElement? Element(string tag)
```

A nested documentation element that has the specified name (e.g. `summary`, `remarks`, etc.).

#### Parameters
- `tag`: The name of the element tag to search inside the comment.

### Element(Func<DocCommentElement, bool>)
```cs
public DocCommentElement? Element(Func<DocCommentElement, bool> p)
```

A nested documentation element that matches the specified predicate `p`.

#### Parameters
- `p`: The predicate to apply on each nested documentation element.

