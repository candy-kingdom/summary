using Summary.Pipelines;
using Summary.Pipes;
using Summary.Pipes.IO;

namespace Summary.Markdown;

public static class MarkdownExtensions
{
    public static SummaryPipeline UseMdRenderer(this SummaryPipeline self, string output) =>
        self.RenderWith(
            new RenderMarkdownPipe()
                .ThenForEach(new SavePipe<Md>(output, x => (x.Name, x.Content)))
                .Then(new FoldPipe<Unit>((_, _) => Unit.Value)));
}