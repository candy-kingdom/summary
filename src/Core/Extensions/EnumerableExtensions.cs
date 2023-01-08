namespace Doc.Net.Core.Extensions;

/// <summary>
///     Extension methods for <see cref="IEnumerable{T}"/>.
/// </summary>
public static class EnumerableExtensions
{
    /// <summary>
    ///     Constructs a new string by placing the specified separator between each item in the specified sequence.
    /// </summary>
    /// <example>
    ///     <code>
    ///         var ss = new[] { "A", "B", "C" };
    ///         var s = ss.Separated(with: ", ");
    ///
    ///         s.Should().Be("A, B, C");
    ///     </code>
    /// </example>
    public static string Separated<T>(this IEnumerable<T> self, string with) =>
        string.Join(with, self);

    /// <summary>
    ///     Filters out all `null` values from the specified sequence.
    /// </summary>
    public static IEnumerable<T> NonNulls<T>(this IEnumerable<T?> self) =>
        self.Where(x => x != null)!;
}