namespace Summary.Extensions;

/// <summary>
///     Extension methods for <see cref="IEnumerable{T}"/>.
/// </summary>
internal static class EnumerableExtensions
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

    /// <summary>
    ///     Applies the specified `map` function on each element in the specified sequence.
    ///     Additionally, passes the optional next element.
    /// </summary>
    public static IEnumerable<V> SelectWithNext<T, V>(this IEnumerable<T> self, Func<T, T?, V> map) =>
        self.Select((x, i) => map(x, self.ElementAtOrDefault(i + 1)));
}