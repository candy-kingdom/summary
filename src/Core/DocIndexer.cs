namespace Summary;

public record DocIndexer(
        DocType Type,
        string FullyQualifiedName,
        string Name,
        string Declaration,
        AccessModifier Access,
        DocComment Comment,
        DocType? DeclaringType,
        DocParam[] Params)
    : DocMember(FullyQualifiedName, Name, Declaration, Access, Comment, DeclaringType);