using System.Diagnostics;
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

    private readonly Options _options;
    private readonly ILogger<SummaryPipeline> _logger;

    private IPipe<Unit, Doc> _parser = new FuncPipe<Unit, Doc>(_ => Doc.Empty);
    private IPipe<Doc, Unit> _render = new FuncPipe<Doc, Unit>(_ => Unit.Value);

    /// <summary>
    ///     Constructs the documentation generation pipeline with default options.
    /// </summary>
    public SummaryPipeline() : this(new()) { }

    /// <summary>
    ///     Constructs the documentation generation pipeline with the specified options.
    /// </summary>
    public SummaryPipeline(Options options)
    {
        _options = options;
        _logger = options.LoggerFactory.CreateLogger<SummaryPipeline>();
    }

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

        await Render(doc);

        Task<Doc> Parse()
        {
            using var _ = _logger.BeginScope("Parsing...");

            return _parser.Run();
        }

        Task Render(Doc doc)
        {
            using var _ = _logger.BeginScope("Rendering...");

            return _render.Run(doc);
        }
    }
}