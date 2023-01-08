# MarkdownRenderPipe
A [`IPipe{I,O}`](./IPipe{I,O}.md)that renders generated document into the sequence of Markdown files.

```cs
public MarkdownRenderPipe : IPipe<Document, Markdown[]>
```

## Methods
### Run
```cs
public Task<Markdown[]> Run(Document input)
```

### Render
```cs
private static Markdown Render(DocMember member)
```

