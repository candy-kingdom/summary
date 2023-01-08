# MarkdownRenderExtensions
Extension methods for better rendering documentation into Markdown format.

```cs
public static MarkdownRenderExtensions 
```

## Methods
### Render
Renders the specified documentation member into Markdown.

```cs
public static Markdown Render(this DocMember self)
```

### Render
```cs
private static void Render(DocMember member, StringBuilder sb, int level = 1)
```

### Render
```cs
private static string Render(IEnumerable<DocCommentNode> nodes)
```

### Render
```cs
private static string Render(DocCommentNode? node)
```

### Trim
```cs
private static IEnumerable<DocCommentNode> Trim(this IEnumerable<DocCommentNode> nodes)
```

