# [Summary.DocCommentElement](../src/Core/DocCommentElement.cs#L11)
```cs
public record DocCommentElement(string Name, DocCommentElementAttribute[] Attributes, DocCommentNode[] Nodes) : DocCommentNode
```

A [`DocCommentNode`](./DocCommentNode.md) that represents a compound element (e.g. summary, remarks, and other XML elements).

_Each element can contain simple text as well as other elements._

## Properties
### [Name](../src/Core/DocCommentElement.cs#L11)
```cs
public string Name { get; }
```

The name of the element (e.g. `remarks`, `summary`, `example`).

### [Attributes](../src/Core/DocCommentElement.cs#L11)
```cs
public DocCommentElementAttribute[] Attributes { get; }
```

### [Nodes](../src/Core/DocCommentElement.cs#L11)
```cs
public DocCommentNode[] Nodes { get; }
```

The sequence of nodes this element consists of.

