# [Summary.DocComment](../src/Core/DocComment.cs#L7)
```cs
public record DocComment(DocCommentNode[] Nodes)
```

A documentation comment parsed from the source code.

## Fields
### [Empty](../src/Core/DocComment.cs#L12)
```cs
public static readonly DocComment Empty
```

An empty documentation comment.

## Properties
### [Nodes](../src/Core/DocComment.cs#L7)
```cs
public DocCommentNode[] Nodes { get; }
```

The sequence of nodes this comment consists of (e.g. `summary`, `remarks`, etc.).

## Methods
### [Param(string)](../src/Core/DocComment.cs#L18)
```cs
public DocCommentElement? Param(string name)
```

A nested `<param>` documentation element that has the specified name.

#### Parameters
- `name`: The name of the parameter to search inside the comment.

### [TypeParam(string)](../src/Core/DocComment.cs#L25)
```cs
public DocCommentElement? TypeParam(string name)
```

A nested `<typeparam>` documentation element that has the specified name.

#### Parameters
- `name`: The name of the parameter to search inside the comment.

### [Element(string, string)](../src/Core/DocComment.cs#L33)
```cs
public DocCommentElement? Element(string tag, string name)
```

A nested documentation element that has the specified name (e.g. `summary`, `remarks`, etc.).

#### Parameters
- `tag`: The name of the element tag to search inside the comment.
- `name`: The value of the `name` attribute of the tag.

### [Element(string)](../src/Core/DocComment.cs#L40)
```cs
public DocCommentElement? Element(string tag)
```

A nested documentation element that has the specified name (e.g. `summary`, `remarks`, etc.).

#### Parameters
- `tag`: The name of the element tag to search inside the comment.

### [Element(Func&lt;DocCommentElement, bool&gt;)](../src/Core/DocComment.cs#L47)
```cs
public DocCommentElement? Element(Func<DocCommentElement, bool> p)
```

A nested documentation element that matches the specified predicate `p`.

#### Parameters
- `p`: The predicate to filter nested documentation elements.

### [Elements(string)](../src/Core/DocComment.cs#L54)
```cs
public IEnumerable<DocCommentElement> Elements(string tag)
```

A sequence of nested documentation elements that have the specified name (e.g. `summary`, `remarks`, etc.).

#### Parameters
- `tag`: The name of the element tag to search inside the comment.

### [Elements(Func&lt;DocCommentElement, bool&gt;)](../src/Core/DocComment.cs#L61)
```cs
public IEnumerable<DocCommentElement> Elements(Func<DocCommentElement, bool> p)
```

A sequence of nested documentation elements that match the specified predicate.

#### Parameters
- `p`: The predicate to filter nested documentation elements.

