# [Summary.Markdown.RenderMarkdownPipe](../src/Plugins/Markdown/RenderMarkdownPipe.cs#L9)
```cs
public class RenderMarkdownPipe : IPipe&lt;Doc, Md[]&gt;
```

A [`IPipe&lt;I, O&gt;`](./Summary.Pipes.IPipe{I,O}.md) that renders generated document into the sequence of Markdown files.

## Methods
### [Run(Doc)](../src/Plugins/Markdown/RenderMarkdownPipe.cs#L11)
```cs
public Task&lt;Md[]&gt; Run(Doc doc)
```

