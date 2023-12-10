# [Summary.Markdown.RenderMarkdownPipe](../src/Plugins/Markdown/RenderMarkdownPipe.cs#L8)
```cs
public class RenderMarkdownPipe : IPipe<Doc, Md[]>
```

A [`IPipe{I,O}`](./IPipe{I,O}.md) that renders generated document into the sequence of Markdown files.

## Methods
### [Run(Doc)](../src/Plugins/Markdown/RenderMarkdownPipe.cs#L15)
```cs
public Task<Md[]> Run(Doc doc)
```

