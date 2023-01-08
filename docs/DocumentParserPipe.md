# DocumentParserPipe
A [`IPipe{I,O}`](./IPipe{I,O}.md)that transforms the specified syntax tree into parsed document.

```cs
public DocumentParserPipe : IPipe<SyntaxTree, Document>
```

## Methods
### Run
```cs
public async Task<Document> Run(SyntaxTree input)
```

