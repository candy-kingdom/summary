# RenderMarkdownPipe
A [`IPipe{I,O}`](./IPipe{I,O}.md) that renders generated document into the sequence of Markdown files.

```cs
public class RenderMarkdownPipe : IPipe<Doc, Md[]>
```

## Methods
### Run
```cs
public Task<Md[]> Run(Doc input)
```

