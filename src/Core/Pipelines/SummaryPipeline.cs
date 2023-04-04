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
    private IPipe<Unit, Doc> _parser = new FuncPipe<Unit, Doc>(_ => Doc.Empty);
    private IPipe<Doc, Unit> _render = new FuncPipe<Doc, Unit>(_ => Unit.Value);

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
    public SummaryPipeline RenderWith(IPipe<Doc, Unit> render)
    {
        _render = render;
        return this;
    }

    /// <summary>
    ///     Executes the pipeline (parser first, then -- renderer).
    /// </summary>
    public async Task Run() =>
        await _parser.Then(_render).Run();
}