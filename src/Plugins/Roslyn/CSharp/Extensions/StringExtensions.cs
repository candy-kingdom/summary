namespace Summary.Roslyn.CSharp.Extensions;

public static class StringExtensions
{
    public static string Space(this string self) =>
        self is "" ? self : $"{self} ";
}