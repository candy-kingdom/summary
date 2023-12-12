# [Summary.DocCommentLiteral](../src/Core/DocCommentLiteral.cs#L15)
```cs
public record DocCommentLiteral(string Value, string LeadingTrivia = "") : DocCommentNode
```

A [`DocCommentNode`](./Summary.DocCommentNode.md) that represents a literal value (e.g. text, space, newline character, etc.).

_Literals are simple tokens that are parsed as text._

## Properties
### [Value](../src/Core/DocCommentLiteral.cs#L15)
```cs
public string Value { get; }
```

The value of the literal.

### [LeadingTrivia](../src/Core/DocCommentLiteral.cs#L15)
```cs
public string LeadingTrivia { get; }
```

The leading trivia of the literal that is not included in the `Value`(i.e. space characters, newlines).

## Methods
### [New(string)](../src/Core/DocCommentLiteral.cs#L20)
```cs
public static DocCommentLiteral New(string value)
```

Constructs a new [`DocCommentLiteral`](./Summary.DocCommentLiteral.md) from the given string.

