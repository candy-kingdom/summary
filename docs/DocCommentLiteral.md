# Summary.DocCommentLiteral
```cs
public record DocCommentLiteral(string Value, string LeadingTrivia = "") : DocCommentNode
```

A [`DocCommentNode`](./DocCommentNode.md) that represents a literal value (e.g. text, space, newline character, etc.).

_Literals are simple tokens that are parsed as text._

## Properties
### Value
```cs
public string Value { get; }
```

The value of the literal.

### LeadingTrivia
```cs
public string LeadingTrivia { get; }
```

The leading trivia of the literal that is not included in the `Value`(i.e. space characters, newlines).

## Methods
### New(string)
```cs
public static DocCommentLiteral New(string value)
```

Constructs a new [`DocCommentLiteral`](./DocCommentLiteral.md) from the given string.

