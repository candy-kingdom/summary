# Summary.Pipelines.SummaryPipeline
A plain Summary pipeline that should be used in simple cases.

_By default, this pipeline supports one parser pipe and one renderer pipe._
_<br />_
_Parser pipe should extract [`Doc`](./Doc.md) from some source (e.g., file system), while_
_renderer pipe should render the parsed [`Doc`](./Doc.md) into some format (e.g., Markdown)_
_and save it somewhere (e.g., file system)._

```cs
public class SummaryPipeline
```

## Methods
### ParseWith(IPipe<Unit, Doc>)
Specifies the custom parser for this pipeline.

```cs
public SummaryPipeline ParseWith(IPipe<Unit, Doc> parser)
```

### RenderWith(IPipe<Doc, Unit>)
Specifies the custom renderer for this pipeline.

```cs
public SummaryPipeline RenderWith(IPipe<Doc, Unit> render)
```

### Run()
Executes the pipeline (parser first, then -- renderer).

```cs
public async Task Run()
```

