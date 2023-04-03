using Summary.Pipes;

namespace Summary.Pipelines;

public class SummaryPipeline
{
    private IPipe<Unit, Doc> _parser = new FuncPipe<Unit, Doc>(_ => Doc.Empty);
    private IPipe<Doc, Unit> _render = new FuncPipe<Doc, Unit>(_ => Unit.Value);

    public SummaryPipeline ParseWith(IPipe<Unit, Doc> parser)
    {
        _parser = parser;
        return this;
    }

    public SummaryPipeline RenderWith(IPipe<Doc, Unit> render)
    {
        _render = render;
        return this;
    }

    public async Task Run() =>
        await _parser.Then(_render).Run();
}