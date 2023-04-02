using Summary.Pipes;
using Summary.Pipes.IO;

namespace Summary.Markdown;

public static class MarkdownExtensions
{
    public static SummaryGen UseMdRenderer(this SummaryGen self, string output) =>
        self.RenderWith(
            new RenderMarkdownPipe()
                .ThenForEach(new SavePipe<Md>(output, x => (x.Name, x.Content)))
                .Then(new FoldPipe<Unit>((_, _) => Unit.Value)));
}