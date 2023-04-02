namespace Summary.Extensions;

public static class StringExtensions
{
    public static string Space(this string self) =>
        self.Wrap(prefix: "", suffix: " ");

    public static string Wrap(this string self, string prefix, string suffix) =>
        self.Map(x => $"{prefix}{x}{suffix}");

    private static string Map(this string self, Func<string, string> map) =>
        self is "" ? self : map(self);
}