namespace Summary.Extensions;

internal static class StringExtensions
{
    /// <summary>
    ///     Adds a space character to the end of the specified string.
    ///     If the string is empty, returns the string as is.
    /// </summary>
    public static string Space(this string self) =>
        self.Wrap("", " ");

    /// <summary>
    ///     Wraps the specified string with the given prefix and suffix strings.
    ///     If the string is empty, returns the string as is.
    /// </summary>
    public static string Wrap(this string self, string prefix, string suffix) =>
        self.Map(x => $"{prefix}{x}{suffix}");

    private static string Map(this string self, Func<string, string> map) =>
        self is "" ? self : map(self);
}