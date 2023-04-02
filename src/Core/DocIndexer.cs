namespace Summary;

public record DocIndexer(
        DocType Type,
        string Name,
        string Declaration,
        AccessModifier Access,
        DocComment Comment,
        DocParam[] Params,
        DocType? DeclaringType)
    : DocMember(Name, Declaration, Access, Comment);