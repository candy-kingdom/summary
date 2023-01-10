# DocComment
An documentation comment parsed from the source code.

```cs
public record DocComment(DocCommentNode[] Nodes)
```

## Fields
### Empty
An empty documentation comment.

```cs
public static readonly DocComment Empty = new(Array.Empty<DocCommentNode>())
```

## Properties
### Nodes
The sequence of nodes this comment consists of (e.g. `summary`, `remarks`, etc.).

```cs
 DocCommentNode[] Nodes { get; }
```

## Methods
### Element
A nested documentation element that has the specified name (e.g. `summary`, `remarks`, etc.).

```cs
public DocCommentElement? Element(string name)
```

#### Parameters
- `string`: The name of the element to search inside the comment.
### Param
A nested <param>documentation element that has the specified name.

```cs
public DocCommentElement? Param(string name)
```

#### Parameters
- `string`: The name of the parameter to search inside the comment.
