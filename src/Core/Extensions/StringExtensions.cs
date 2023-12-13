using System.Text.RegularExpressions;

namespace Summary.Extensions;

internal static partial class StringExtensions
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
}