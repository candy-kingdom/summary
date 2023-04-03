# Doc
A document parsed from the source code or an assembly.

```cs
public record Doc(DocMember[] Members)
```

## Fields
### Empty
An empty document.

```cs
public static readonly Doc Empty = new(Array.Empty<DocMember>())
```

## Properties
### Members
The sequence of members this doc contains.

```cs
public DocMember[] Members { get; }
```

## Methods
### Merge(Doc, Doc)
Merges two documents together returning the new merged document.

```cs
public static Doc Merge(Doc a, Doc b)
```

#### Parameters
- `a`: The first document to merge.
- `b`: The second document to merge.

### Declaration(DocType?<DocType>)
A type declaration that matches the specified type.

```cs
public DocTypeDeclaration? Declaration(DocType? type)
```

