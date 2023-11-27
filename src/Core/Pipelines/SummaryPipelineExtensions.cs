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

    /// <summary>
    ///     Disables <see cref="FilterPublicMembersPipe"/> filter in the pipeline.
    ///     This makes the generator to include private members into the parsed document.
    /// </summary>
    public static SummaryPipeline IncludeNonPublicMembers(this SummaryPipeline self)
    {
        self.Filters.RemoveAll(x => x is FilterPublicMembersPipe);
        return self;
    }

    /// <summary>
    ///     Adds the given filter into the pipeline.
    /// </summary>
    /// <seealso cref="SummaryPipeline.Filters"/>
    public static SummaryPipeline UseFilter(this SummaryPipeline self, IPipe<Doc, Doc> filter)
    {
        self.Filters.Add(filter);
        return self;
    }
}