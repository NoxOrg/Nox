namespace Nox.Extensions;

internal static class StringExtensions
{
    public static string StripQueryParameters(this string input) => input.Split('?')[0];
}
