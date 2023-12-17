namespace Summary.Extensions;

/// <summary>
///     Extension methods for <see cref="IEnumerable{T}"/>.
/// </summary>
internal static class EnumerableExtensions
{
    private class Comparer<T>(Func<T, T, bool> equals, Func<T, int> hash) : IEqualityComparer<T>
    {
        public bool Equals(T? x, T? y)
        {
            if (x is null && y is null)
                return true;
            if (x is null || y is null)
                return false;

            return equals(x, y);
        }

        public int GetHashCode(T obj) =>
            hash(obj);
    }

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
    ///     Filters out all <c>null</c> values from the specified sequence.
    /// </summary>
    public static IEnumerable<T> NonNulls<T>(this IEnumerable<T?> self) =>
        self.Where(x => x != null)!;

    /// <summary>
    ///     Applies the specified <c>map</c> function on each element in the specified sequence.
    ///     Additionally, passes the optional next element.
    /// </summary>
    public static IEnumerable<V> SelectWithNext<T, V>(this IEnumerable<T> self, Func<T, T?, V> map) =>
        self.Select((x, i) => map(x, self.ElementAtOrDefault(i + 1)));

    /// <summary>
    ///     Whether the two sequences are equal.
    /// </summary>
    public static bool SequenceEqual<T>(this IEnumerable<T> self, IEnumerable<T> other, Func<T, T, bool> equal) where T : notnull =>
        self.SequenceEqual(other, new Comparer<T>(equal, x => x.GetHashCode()));

    /// <summary>
    ///     Performs the DFS on all items of the specified sequence using provided <paramref name="nested"/> func
    ///     to obtain nodes one level deeper from the given.
    /// </summary>
    public static IEnumerable<T> Dfs<T>(this IEnumerable<T> self, Func<T, IEnumerable<T>> nested)
    {
        return FromMany(self);

        IEnumerable<T> FromMany(IEnumerable<T> x) =>
            x.SelectMany(FromOne);

        IEnumerable<T> FromOne(T x)
        {
            yield return x;

            foreach (var y in FromMany(nested(x)))
                yield return y;
        }
    }
}