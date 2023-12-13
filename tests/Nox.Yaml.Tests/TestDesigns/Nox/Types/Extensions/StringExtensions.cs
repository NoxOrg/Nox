namespace Nox.Yaml.Tests.TestDesigns.Nox.Types.Extensions;

/// <summary>
/// The string extensions.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Normalizes the new lines.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A string.</returns>
    public static string NormalizeNewLines(this string value)
    {
        return value
            .Replace("\r\n", Environment.NewLine);
    }
}
