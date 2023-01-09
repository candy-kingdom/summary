# DocType
A [`DocMember`](./DocMember.md) that represents a documented type in the parsed source code.

```cs
public record DocType(string Name, string Declaration, AccessModifier Access, DocComment Comment, DocMember[] Members) : DocMember(Name, Declaration, Access, Comment)
```

