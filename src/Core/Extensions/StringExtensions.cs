namespace Summary.Extensions;

internal static class StringExtensions
{
    /// <summary>
    ///     Adds a space character to the end of the specified string.
    ///     If the string is empty, returns the string as is.
    /// </summary>
    public static string Space(this string self) =>
        self.Surround("", " ");

    /// <summary>
    ///     Surrounds the specified string with the given prefix and suffix strings.
    ///     If the string is empty, returns the string as is.
    /// </summary>
    public static string Surround(this string self, string left, string right) =>
        self.Map(x => $"{left}{x}{right}");

    /// <summary>
    ///     Surrounds the specified string with the given prefix and suffix strings
    ///     if the specified condition is satisfied. If the string is empty, returns the string as is.
    /// </summary>
    public static string Surround(this string self, string left, string right, bool when) =>
        when ? self.Surround(left, right) : self;

    private static string Map(this string self, Func<string, string> map) =>
        self is "" ? self : map(self);

    /// <summary>
    ///     Converts the given relative path into full path.
    /// </summary>
    public static string AsFullPath(this string self) =>
        Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, self));

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
        self.Replace("<", "{").Replace(">", "}").Replace(" ", "");
}