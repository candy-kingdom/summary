# [Summary.Markdown.RenderMarkdownPipe](../src/Plugins/Markdown/RenderMarkdownPipe.cs#L9)
```cs
public class RenderMarkdownPipe : IPipe<Doc, Md[]>
```

A [`IPipe<I, O>`](./Summary.Pipes.IPipe{I,O}.md) that renders generated document into the sequence of Markdown files.

## Methods
### [Run(Doc)](../src/Plugins/Markdown/RenderMarkdownPipe.cs#L11)
```cs
public Task<Md[]> Run(Doc doc)
```

