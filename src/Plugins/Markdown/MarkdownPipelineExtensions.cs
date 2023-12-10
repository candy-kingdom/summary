using Summary.Extensions;
using Summary.Pipelines;
using Summary.Pipes;
using Summary.Pipes.IO;

namespace Summary.Markdown;

/// <summary>
///     A set of extension methods that extend different pipelines with Markdown rendering.
/// </summary>
public static class MarkdownPipelineExtensions
{
    /// <summary>
    ///     Adds a Markdown renderer to the specified pipeline.
    /// </summary>
    /// <remarks>
    ///     The renderer will write all the rendered Markdown files to the specified output directory.
    /// </remarks>
    public static SummaryPipeline UseMdRenderer(this SummaryPipeline self, string output, bool cleanup = true) =>
        self.RenderWith(options =>
            new RenderMarkdownPipe(output)
                .Then(new CleanupDirPipe<Md[]>(output), when: cleanup)
                .ThenForEach(new SavePipe<Md>(output, x => (x.Name, x.Content)))
                .Logged(options.LoggerFactory, $"Write Markdown files into directory '{output.AsFullPath()}'")
                .Fold());
}