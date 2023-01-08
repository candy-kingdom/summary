# SyntaxExtensions
Extension methods for different Roslyn syntax nodes that helps constructing document members.

```cs
public static SyntaxExtensions 
```

## Methods
### Attributes
The attributes formatted as a string of the specified member.

```cs
public static string Attributes(this MemberDeclarationSyntax self)
```

### Access
The access modifier of the specified member.

```cs
public static AccessModifier Access(this MemberDeclarationSyntax self)
```

### Accessors
Formatted accessors (e.g. `{ get; set; }`, `{ get; init }`, etc.) of the specified property.

```cs
public static string Accessors(this PropertyDeclarationSyntax self)
```

### Members
Parses document members from the specified syntax node.

```cs
public static DocMember[] Members(this SyntaxNode self)
```

### Member
Converts the specified syntax node to a document member.

```cs
public static DocMember? Member(this SyntaxNode self)
```

### Type
Parses the specified syntax node to a document type.

```cs
public static DocType Type(this TypeDeclarationSyntax self)
```

### Field
Parses the specified syntax node to a document field.

```cs
public static DocField Field(this FieldDeclarationSyntax self)
```

### Property
Parses the specified syntax node to a document property.

```cs
public static DocProperty Property(this PropertyDeclarationSyntax self)
```

### Method
Parses the specified syntax node to a document method.

```cs
public static DocMethod Method(this MethodDeclarationSyntax self)
```

### Comment
Parses the documentation comment of the specified member.

```cs
public static DocComment Comment(this MemberDeclarationSyntax self)
```

