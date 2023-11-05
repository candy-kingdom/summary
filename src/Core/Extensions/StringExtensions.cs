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

    private static string Map(this string self, Func<string, string> map) =>
        self is "" ? self : map(self);
}