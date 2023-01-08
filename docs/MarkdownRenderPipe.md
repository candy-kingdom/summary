# MarkdownRenderPipe
A [`IPipe{I,O}`](./IPipe{I,O}.md)that renders generated document into the sequence of Markdown files.

```cs
public MarkdownRenderPipe : IPipe<Doc, Markdown[]>
```

## Methods
### Run
```cs
public Task<Markdown[]> Run(Doc input)
```

