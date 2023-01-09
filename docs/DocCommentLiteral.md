# DocCommentLiteral
A [`DocCommentNode`](./DocCommentNode.md) that represents a literal value (e.g. text, space, newline character, etc.).

_Literals are simple tokens that are parsed as text._

```cs
public record DocCommentLiteral(string Value, string LeadingTrivia = "") : DocCommentNode
```

## Methods
### New
Constructs a new [`DocCommentLiteral`](./DocCommentLiteral.md) from the given string.

```cs
public static DocCommentLiteral New(string value)
```

