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
    ///     Enables default filters for the given pipeline (i.e. a filter that removes all non-public members).
    /// </summary>
    public static SummaryPipeline UseDefaultFilters(this SummaryPipeline self) => self
        .IncludeOnly(AccessModifier.Public);

    /// <summary>
    ///     Includes only members that have at least the given access modifier.
    /// </summary>
    /// <example>
    ///     In order to include both <c>internal</c> and <c>public</c> members in the generated docs,
    ///     you can call this method as follows:
    ///     <para><code>
    ///         var pipeline = ...;
    ///
    ///         pipeline.IncludeAtLeast(AccessModifier.Internal);
    ///     </code></para>
    /// </example>
    public static SummaryPipeline IncludeAtLeast(this SummaryPipeline self, AccessModifier access) => self
        .UseFilter(new FilterMemberPipe(x => x.Access >= access));

    /// <summary>
    ///     Includes only members that have at least the given access modifier.
    /// </summary>
    /// <example>
    ///     In order to include onl <c>internal</c> members in the generated docs,
    ///     you can call this method as follows:
    ///     <para><code>
    ///         var pipeline = ...;
    ///
    ///         pipeline.IncludeOnly(AccessModifier.Internal);
    ///     </code></para>
    /// </example>
    public static SummaryPipeline IncludeOnly(this SummaryPipeline self, AccessModifier access) => self
        .UseFilter(new FilterMemberPipe(x => x.Access == access));

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