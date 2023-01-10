# Doc
A document parsed from the source code or an assembly.

```cs
public record Doc(DocMember[] Members)
```

## Properties
### Members
```cs
 DocMember[] Members { get; }
```

## Methods
### Merge
Merges two documents together returning the new merged document.

```cs
public static Doc Merge(Doc a, Doc b)
```

