using System;
using System.Globalization;
using System.Linq;

namespace Nox.Types;

public class ColorConverter
{
    public static Color ConvertFromString(string strValue, CultureInfo culture)
    {
        string text = strValue.Trim();

        if (text.Length == 0)
        {
            return Color.Empty;
        }

        {
            System.Drawing.Color color;

            if (KnownColor.TryGetNamedColor(text, out color))
            {
                var c = System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);

                return Color.FromRgba(c.A, c.R, c.G, c.B);
            }
        }

        char listSeparator = culture.TextInfo.ListSeparator[0];

        if (!text.Contains(listSeparator))
        {
            if ((text.StartsWith("'") && text.EndsWith("'")) ||
                (text.StartsWith("\"") && text.EndsWith("\"")))
            {
                string colorName = text.Trim('\'', '\"');
                return Color.FromName(colorName);
            }
            else if (text.StartsWith("#") && text.Length == 7 ||
                     (text.StartsWith("0x", StringComparison.OrdinalIgnoreCase) ||
                      text.StartsWith("&h", StringComparison.OrdinalIgnoreCase)) && text.Length == 8)
            {
                try
                {
                    int argb = Convert.ToInt32(text.Substring(text[0] == '#' ? 1 : 2), 16);
                    byte a = (byte)((argb >> 24) & 0xFF);
                    byte r = (byte)((argb >> 16) & 0xFF);
                    byte g = (byte)((argb >> 8) & 0xFF);
                    byte b = (byte)(argb & 0xFF);
                    return PossibleKnownColor(System.Drawing.Color.FromArgb(a, r, g, b));
                }
                catch (Exception)
                {
                    return Color.Empty;
                }
            }
        }

        string[] tokens = text.Split(listSeparator);
        return tokens.Length switch
        {
            1 => PossibleKnownColor(System.Drawing.Color.FromArgb(IntFromString(tokens[0], culture))),
            3 => PossibleKnownColor(System.Drawing.Color.FromArgb(IntFromString(tokens[0], culture), IntFromString(tokens[1], culture), IntFromString(tokens[2], culture))),
            4 => PossibleKnownColor(System.Drawing.Color.FromArgb(IntFromString(tokens[0], culture), IntFromString(tokens[1], culture), IntFromString(tokens[2], culture), IntFromString(tokens[3], culture))),
            _ => Color.Empty,
        };
    }

    private static Color PossibleKnownColor(System.Drawing.Color color)
    {
        if (KnownColor.Colors.Values.Any(knc => knc.ToArgb() == color.ToArgb()))
        {
            return Color.FromRgba(color.A, color.R, color.G, color.B);
        }

        return Color.FromRgba(color.A, color.R, color.G, color.B);
    }

    private static int IntFromString(string text, CultureInfo culture)
    {
        text = text.Trim();

        if (string.IsNullOrEmpty(text))
        {
            throw new ArgumentException("Provided string is null or empty", nameof(text));
        }

        try
        {
            if (text[0] == '#')
            {
                return Convert.ToInt32(text.Substring(1), 16);
            }
            else if (text.StartsWith("0x", StringComparison.OrdinalIgnoreCase) || text.StartsWith("&h", StringComparison.OrdinalIgnoreCase))
            {
                return Convert.ToInt32(text.Substring(2), 16);
            }
            else
            {
                return Convert.ToInt32(text, culture);
            }
        }
        catch (FormatException)
        {
            throw new ArgumentException($"Unable to convert '{text}' to a number", nameof(text));
        }
        catch (OverflowException)
        {
            throw new ArgumentException($"'{text}' is too large to fit in an integer", nameof(text));
        }
    }
}