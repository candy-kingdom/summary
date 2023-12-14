# [Summary.Roslyn.CSharp.Extensions.DocMemberExtensions](../src/Plugins/Roslyn/CSharp/Extensions/DocMemberExtensions.cs#L8)
```cs
public static class DocMemberExtensions
```

A set of extension methods for [`DocMember`](./Summary.DocMember.md).

## Methods
### [WithComment<T>(T, MemberDeclarationSyntax)](../src/Plugins/Roslyn/CSharp/Extensions/DocMemberExtensions.cs#L13)
```cs
public static T WithComment<T>(this T self, MemberDeclarationSyntax syntax)
```

Parses the comment from the specified member syntax and attaches it to this doc member.

