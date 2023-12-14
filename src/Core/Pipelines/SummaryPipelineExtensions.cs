using Microsoft.Extensions.Logging;
using Summary.Pipes;
using Summary.Pipes.Filters;

namespace Summary.Pipelines;

/// <summary>
///     Convenient extensions for <see cref="SummaryPipeline"/>.
/// </summary>
public static class SummaryPipelineExtensions
{
    /// <summary>
    ///     Specifies the logger factory to use for pipes inside the pipeline.
    /// </summary>
    /// <remarks>
    ///     This method should be called <i>before</i> anything else so that
    ///     given logger factory is passed into all subsequent calls.
    /// </remarks>
    public static SummaryPipeline UseLoggerFactory(this SummaryPipeline self, ILoggerFactory factory) =>
        self.Customize(options => options.UseLoggerFactory(factory));
}