# DocField
A [`DocMember`](./DocMember.md) that represents a documented property in the parsed source code.

```cs
public record DocField(string Name, string Declaration, AccessModifier Access, DocComment Comment) : DocMember(Name, Declaration, Access, Comment)
```

