namespace Summary;

public record DocDelegate(
    string Name,
    string Declaration,
    AccessModifier Access,
    DocComment Comment,
    DocParam[] Params,
    DocTypeParam[] TypeParams,
    DocType? DeclaringType) : DocMember(Name, Declaration, Access, Comment);
