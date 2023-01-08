# PublicFilterPipe
A [`IPipe{I,O}`](./IPipe{I,O}.md)that filters out non-public types and members from the parsed document.

```cs
public PublicFilterPipe : IPipe<Document, Document>
```

## Methods
### Run
```cs
public Task<Document> Run(Document input)
```

