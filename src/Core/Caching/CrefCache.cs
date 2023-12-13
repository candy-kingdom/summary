using System.Collections.Concurrent;
using System.Text.RegularExpressions;

namespace Summary.Caching;

/// <summary>
///     A cache of different <c>cref</c> conversions.
/// </summary>
public static partial class CrefCache
{
    private static readonly ConcurrentDictionary<string, string> Crefs = new();
    private static readonly ConcurrentDictionary<string, string> Normal = new();
    private static readonly ConcurrentDictionary<string, string> RawCrefs = new();

    /// <summary>
    ///     Converts the given string into the format of <c>cref</c> attribute value.
    /// </summary>
    /// <example>
    ///     In the following example, the <c>"Some&lt;T1, T2&gt;"</c> string
    ///     (which represents the name of some type)
    ///     is converted into <c>"Some{T1,T2}"</c> as if it was a value of a link
    ///     (e.g., &lt;see cref="Some{T1,T2}"&gt;):
    ///     <para><code>
    ///         var a = "Some&lt;T1, T2&gt;";
    ///         var b = a.AsCref();
    ///         <br/>
    ///         b.Should().Be("Some{T1,T2}");
    ///     </code></para>
    /// </example>
    public static string AsCref(this string self) =>
        Crefs.TryGetValue(self, out var cref)
            ? cref
            : Crefs[self] = self.Replace("<", "{").Replace(">", "}").Replace(" ", "");

    /// <summary>
    ///     Converts the given string into the format of <c>cref</c> attribute value
    ///     but also removes all generic parameter names.
    /// </summary>
    /// <example>
    ///     In the following example, the <c>"Some&lt;T1, T2&gt;"</c> string
    ///     (which represents the name of some type)
    ///     is converted into <c>"Some{,}"</c>, the raw form of <c>cref</c> that can be used for comparisons
    ///     without involving generic type parameter names.
    ///     <para><code>
    ///         var a = "Some&lt;T1, T2&gt;";
    ///         var b = a.AsCref();
    ///         <br/>
    ///         b.Should().Be("Some{,}");
    ///     </code></para>
    /// </example>
    public static string AsRawCref(this string self) =>
        RawCrefs.TryGetValue(self, out var cref)
            ? cref
            : RawCrefs[self] = RawCrefRegex().Replace(self.AsCref(), "");

    [GeneratedRegex(@"(?<={)[^{},]*(?=,)|(?<=,)[^{},]*(?=})")]
    private static partial Regex RawCrefRegex();

    /// <summary>
    ///     Converts the given string from the format of <c>cref</c> attribute value.
    /// </summary>
    /// <example>
    ///     In the following example, the <c>"Some&lt;T1, T2&gt;"</c> string
    ///     In the following example, the <c>"Some{T1,T2}"</c> string
    ///     (which represents the name of some type in the <c>cref</c> format)
    ///     is converted into <c>"Some&lt;T1, T2&gt;</c> so that it can be displayed somewhere.
    ///     <para><code>
    ///         var a = "Some{T1,T2}";
    ///         var b = a.AsCref();
    ///         <br/>
    ///         b.Should().Be("Some&lt;T1, T2&gt;");
    ///     </code></para>
    /// </example>
    public static string FromCref(this string self) =>
        Normal.TryGetValue(self, out var normal)
            ? normal
            : Normal[self] = self
                .AsCref()
                .Replace("{", "<")
                .Replace("}", ">")
                .Replace(",", ", ");
}