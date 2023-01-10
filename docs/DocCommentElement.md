# DocCommentElement
A [`DocCommentNode`](./DocCommentNode.md) that represents a compound element (e.g. summary, remarks, and other XML elements).

_Each element can contain simple text as well as other elements._

```cs
public record DocCommentElement(string Name, DocCommentElementAttribute[] Attributes, DocCommentNode[] Nodes) : DocCommentNode
```

## Properties
### Name
The name of the element (e.g. `remarks`, `summary`, `example`).

```cs
 string Name { get; }
```

### Attributes
```cs
 DocCommentElementAttribute[] Attributes { get; }
```

### Nodes
The sequence of nodes this element consists of.

```cs
 DocCommentNode[] Nodes { get; }
```

