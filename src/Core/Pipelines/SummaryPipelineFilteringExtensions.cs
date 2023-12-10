using Summary.Pipes;
using Summary.Pipes.Filters;

namespace Summary.Pipelines;

/// <summary>
///     A set of extensions for <see cref="SummaryPipeline"/> that add support for filtering functionality.
/// </summary>
public static class FilteringExtensions
{
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
        .WithAccess(x => x >= access);

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
        .WithAccess(x => x == access);

    /// <summary>
    ///     Includes only members that have the access modifier that satisfies the given predicate.
    /// </summary>
    public static SummaryPipeline WithAccess(this SummaryPipeline self, Func<AccessModifier, bool> p) => self
        .UseFilter(new FilterMemberPipe(x => p(x.Access), x => x.WithAccess(p)));

    private static DocMember WithAccess(this DocMember member, Func<AccessModifier, bool> p) => member switch
    {
        DocProperty property => property with
        {
            Accessors = property.Accessors.Where(x => x.Access is not null && p(x.Access.Value)).ToArray(),
        },

        _ => member,
    };

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