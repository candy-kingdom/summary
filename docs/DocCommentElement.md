# DocCommentElement
A [`DocCommentNode`](./DocCommentNode.md) that represents a compound element (e.g. summary, remarks, and other XML elements).

_Each element can contain simple text as well as other elements._

```cs
public record DocCommentElement(string Name, DocCommentNode[] Nodes) : DocCommentNode
```

## Properties
### Name
```cs
 string Name { get; }
```

### Nodes
```cs
 DocCommentNode[] Nodes { get; }
```

