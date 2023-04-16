# Summary.Markdown.RenderMarkdownPipe
```cs
public class RenderMarkdownPipe : IPipe<Doc, Md[]>
```

A [`IPipe{I,O}`](./IPipe{I,O}.md) that renders generated document into the sequence of Markdown files.

## Methods
### Run(Doc)
```cs
public Task<Md[]> Run(Doc input)
```

