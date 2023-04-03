namespace Summary;

public record DocIndexer(
        DocType Type,
        string Name,
        string Declaration,
        AccessModifier Access,
        DocComment Comment,
        DocType? DeclaringType,
        DocParam[] Params)
    : DocMember(Name, Declaration, Access, Comment, DeclaringType);