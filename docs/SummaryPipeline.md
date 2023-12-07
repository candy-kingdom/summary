# Summary.Pipelines.SummaryPipeline
```cs
public class SummaryPipeline
```

A plain Summary pipeline that should be used in simple cases.

_By default, this pipeline supports one parser pipe and one renderer pipe._
_<br />_
_Parser pipe should extract [`Doc`](./Doc.md) from some source (e.g., file system), while_
_renderer pipe should render the parsed [`Doc`](./Doc.md) into some format (e.g., Markdown)_
_and save it somewhere (e.g., file system)._

## Properties
### LoggerFactory
```cs
public ILoggerFactory LoggerFactory { get; }
```

The factory that provides logger implementations.

### Filters
```cs
public List<IPipe<Doc, Doc>> Filters { get; }
```

The list of all filters applied after the document is parsed.

_Filters are applied in a separate run after the document is successfully parsed._

## Methods
### UseLoggerFactory(ILoggerFactory)
```cs
public Options UseLoggerFactory(ILoggerFactory loggers)
```

Specifies the logger factory that will be used to create loggers for the pipeline.

### Customize(Func<Options, Options>)
```cs
public SummaryPipeline Customize(Func<Options, Options> options)
```

Customizes the default pipeline options using the specified delegate.

### ParseWith(Func<Options, IPipe<Unit, Doc>>)
```cs
public SummaryPipeline ParseWith(Func<Options, IPipe<Unit, Doc>> parser)
```

Specifies the custom parser with logging support for this pipeline.

### ParseWith(IPipe<Unit, Doc>)
```cs
public SummaryPipeline ParseWith(IPipe<Unit, Doc> parser)
```

Specifies the custom parser for this pipeline.

### RenderWith(Func<Options, IPipe<Doc, Unit>>)
```cs
public SummaryPipeline RenderWith(Func<Options, IPipe<Doc, Unit>> render)
```

Specifies the custom renderer for this pipeline.

### RenderWith(IPipe<Doc, Unit>)
```cs
public SummaryPipeline RenderWith(IPipe<Doc, Unit> render)
```

Specifies the custom renderer for this pipeline.

### Run()
```cs
public async Task Run()
```

Executes the pipeline (parser first, then -- renderer).

