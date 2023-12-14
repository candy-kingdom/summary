# [Summary.Doc](../src/Core/Doc.cs#L9)
```cs
public record Doc(DocMember[] Members)
```

A document parsed from the source code or an assembly.

## Fields
### [Empty](../src/Core/Doc.cs#L14)
```cs
public static readonly Doc Empty
```

An empty document.

## Properties
### [Members](../src/Core/Doc.cs#L9)
```cs
public DocMember[] Members { get; }
```

The sequence of members this doc contains.

## Methods
### [Merge(Doc, Doc)](../src/Core/Doc.cs#L21)
```cs
public static Doc Merge(Doc a, Doc b)
```

Merges two documents together returning the new merged document.

#### Parameters
- `a`: The first document to merge.
- `b`: The second document to merge.

### [Declaration(DocType?<DocType>)](../src/Core/Doc.cs#L29)
```cs
public DocTypeDeclaration? Declaration(DocType? type)
```

A type declaration that matches the specified type.

