# DocComment
An documentation comment parsed from the source code.

```cs
public record DocComment(DocCommentNode[] Nodes)
```

## Fields
### Empty
An empty documentation comment.

```cs
public static readonly DocComment Empty
```

## Properties
### Nodes
The sequence of nodes this comment consists of (e.g. `summary`, `remarks`, etc.).

```cs
public DocCommentNode[] Nodes { get; }
```

## Methods
### Param(string)
A nested <param>documentation element that has the specified name.

```cs
public DocCommentElement? Param(string name)
```

#### Parameters
- `name`: The name of the parameter to search inside the comment.

### TypeParam(string)
A nested <typeparam>documentation element that has the specified name.

```cs
public DocCommentElement? TypeParam(string name)
```

#### Parameters
- `name`: The name of the parameter to search inside the comment.

### Element(string, string)
A nested documentation element that has the specified name (e.g. `summary`, `remarks`, etc.).

```cs
public DocCommentElement? Element(string tag, string name)
```

#### Parameters
- `tag`: The name of the element tag to search inside the comment.
- `name`: The value of the `name` attribute of the tag.

### Element(string)
A nested documentation element that has the specified name (e.g. `summary`, `remarks`, etc.).

```cs
public DocCommentElement? Element(string tag)
```

#### Parameters
- `tag`: The name of the element tag to search inside the comment.

### Element(Func<DocCommentElement, bool>)
A nested documentation element that matches the specified predicate `p`.

```cs
public DocCommentElement? Element(Func<DocCommentElement, bool> p)
```

#### Parameters
- `p`: The predicate to apply on each nested documentation element.

