using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Summary.Pipes;

namespace Summary.Pipelines;

/// <summary>
///     A plain Summary pipeline that should be used in simple cases.
/// </summary>
/// <remarks>
///     By default, this pipeline supports one parser pipe and one renderer pipe.
///     <br />
///     Parser pipe should extract <see cref="Doc" /> from some source (e.g., file system), while
///     renderer pipe should render the parsed <see cref="Doc" /> into some format (e.g., Markdown)
///     and save it somewhere (e.g., file system).
/// </remarks>
public class SummaryPipeline
{
    /// <summary>
    ///     A set of options that configure the behavior of the summary pipeline.
    /// </summary>
    public class Options
    {
        private ILoggerFactory? _loggerFactory;

        /// <summary>
        ///     The factory that provides logger implementations.
        /// </summary>
        public ILoggerFactory LoggerFactory => _loggerFactory ?? NullLoggerFactory.Instance;

        /// <summary>
        ///     Specifies the logger factory that will be used to create loggers for the pipeline.
        /// </summary>
        public Options UseLoggerFactory(ILoggerFactory loggers) =>
            With(_loggerFactory = loggers);

        private Options With<T>(T _) => this;
    }

    private ILogger<SummaryPipeline> _logger = null!;
    private Options _options = null!;

    private IPipe<Unit, Doc> _parser = new FuncPipe<Unit, Doc>(_ => Doc.Empty);
    private IPipe<Doc, Unit> _render = new FuncPipe<Doc, Unit>(_ => Unit.Value);


    /// <summary>
    ///     Constructs the documentation generation pipeline with default options.
    /// </summary>
    public SummaryPipeline() : this(new()) { }

    /// <summary>
    ///     Constructs the documentation generation pipeline with the specified options.
    /// </summary>
    public SummaryPipeline(Options options) =>
        Set(options);

    /// <summary>
    ///     The list of all filters applied after the document is parsed.
    /// </summary>
    /// <remarks>
    ///     Filters are applied in a separate run after the document is successfully parsed.
    /// </remarks>
    public List<IPipe<Doc, Doc>> Filters { get; } = new();

    /// <summary>
    ///     Customizes the default pipeline options using the specified delegate.
    /// </summary>
    public SummaryPipeline Customize(Func<Options, Options> options) =>
        Set(options(_options));

    /// <summary>
    ///     Specifies the custom parser with logging support for this pipeline.
    /// </summary>
    public SummaryPipeline ParseWith(Func<Options, IPipe<Unit, Doc>> parser)
    {
        _parser = parser(_options);
        return this;
    }

    /// <summary>
    ///     Specifies the custom parser for this pipeline.
    /// </summary>
    public SummaryPipeline ParseWith(IPipe<Unit, Doc> parser)
    {
        _parser = parser;
        return this;
    }

    /// <summary>
    ///     Specifies the custom renderer for this pipeline.
    /// </summary>
    public SummaryPipeline RenderWith(Func<Options, IPipe<Doc, Unit>> render)
    {
        _render = render(_options);
        return this;
    }

    /// <summary>
    ///     Specifies the custom renderer for this pipeline.
    /// </summary>
    public SummaryPipeline RenderWith(IPipe<Doc, Unit> render)
    {
        _render = render;
        return this;
    }

    /// <summary>
    ///     Executes the pipeline (parser first, then -- renderer).
    /// </summary>
    public async Task Run()
    {
        var doc = await Parse();

        doc = await Filter(doc);

        await Render(doc);

        Task<Doc> Parse()
        {
            using var _ = _logger.BeginScope(nameof(Parse));

            return _parser.Run();
        }

        async Task<Doc> Filter(Doc doc)
        {
            using var _ = _logger.BeginScope(nameof(Filter));

            foreach (var filter in Filters)
                doc = await filter.Run(doc);

            return doc;
        }

        Task Render(Doc doc)
        {
            using var _ = _logger.BeginScope(nameof(Render));

            return _render.Run(doc);
        }
    }

    private SummaryPipeline Set(Options options)
    {
        _options = options;
        _logger = options.LoggerFactory.CreateLogger<SummaryPipeline>();

        return this;
    }
}