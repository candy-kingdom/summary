# InlineInheritDocPipe
A [`IPipe{I,O}`](./IPipe{I,O}.md) that inlines `<inheritdoc/>` tags.

_Under the hood, the process of inlining works as follows:_
_- Each member in the_

```cs
public class InlineInheritDocPipe : IPipe<Doc, Doc>
```

## Methods
### Run(Doc)
```cs
public Task<Doc> Run(Doc doc)
```

