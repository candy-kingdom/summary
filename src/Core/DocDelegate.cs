namespace Summary;

public record DocDelegate(
    string FullyQualifiedName,
    string Name,
    string Declaration,
    AccessModifier Access,
    DocComment Comment,
    DocParam[] Params,
    DocTypeParam[] TypeParams,
    DocType? DeclaringType) : DocMethod(FullyQualifiedName, Name, Declaration, Access, Comment, DeclaringType, Params,
    TypeParams);