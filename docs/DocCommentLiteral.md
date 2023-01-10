# DocCommentLiteral
A [`DocCommentNode`](./DocCommentNode.md) that represents a literal value (e.g. text, space, newline character, etc.).

_Literals are simple tokens that are parsed as text._

```cs
public record DocCommentLiteral(string Value, string LeadingTrivia = "") : DocCommentNode
```

## Properties
### Value
The value of the literal.

```cs
public string Value { get; }
```

### LeadingTrivia
The leading trivia of the literal that is not included in the <paramref name="Value"/>(i.e. space characters, newlines).

```cs
public string LeadingTrivia { get; }
```

## Methods
### New
Constructs a new [`DocCommentLiteral`](./DocCommentLiteral.md) from the given string.

```cs
public static DocCommentLiteral New(string value)
```

