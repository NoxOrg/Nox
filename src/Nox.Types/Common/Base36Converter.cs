using System.Text;

namespace Nox.Types.Common;

/// <summary>
/// Utility methods for converting value to Base36 string.
/// </summary>
public static class Base36Converter
{
    private const int Base = 36;
    private const string Chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    /// <summary>
    /// Converts integer value to Base36 string.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string ToBase36(uint value)
    {
        var result = new StringBuilder(64);

        while (value > 0)
        {
            result.Append(Chars[(int)(value % Base)]);
            value /= Base;
        }

        return result.ToString();
    }
}