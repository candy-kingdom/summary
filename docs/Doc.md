# Doc
A document parsed from the source code or an assembly.

```cs
public record Doc(DocMember[] Members)
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
- `b`: The first document to merge.
