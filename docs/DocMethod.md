# DocMethod
A [`DocMember`](./DocMember.md) that represents a documented method in the parsed source code.

```cs
public record DocMethod(string Name, string Declaration, AccessModifier Access, DocComment Comment) : DocMember(Name, Declaration, Access, Comment)
```

