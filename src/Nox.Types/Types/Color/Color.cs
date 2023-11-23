using System;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Color"/> type and value object. 
/// </summary>
public class Color : ValueObject<string, Color>
{
    private readonly Regex _hexColorRegex = new Regex(@"^#(([A-Fa-f0-9]{3})|([A-Fa-f0-9]{6})|([A-Fa-f0-9]{8}))$");

    /// <summary>
    /// Creates a new instance of <see cref="Color"/> object.
    /// </summary>
    public Color()
    {
        Value = "#00000000";
    }

    /// <summary>
    /// Creates a <see cref="Color"/> object from a <see cref="System.Drawing.Color"/>.
    /// </summary>
    /// <param name="color">the color to be parsed.</param>
    public static Color From(System.Drawing.Color color)
    {
        return From($"#{color.A:X2}{color.R:X2}{color.G:X2}{color.B:X2}");
    }

    /// <summary>
    /// Creates a new instance of <see cref="Color"/> object.
    /// </summary>
    /// <param name="red">The red color.</param>
    /// <param name="green">The green color.</param>
    /// <param name="blue">The blue color.</param>
    /// <exception cref="NoxTypeValidationException"></exception>
    public static Color From(byte red, byte green, byte blue)
    {
        return From(255, red, green, blue);
    }

    /// <summary>
    /// Creates a new instance of <see cref="Color"/> object.
    /// </summary>
    /// <param name="alpha">The alpha color.</param>
    /// <param name="red">The red color.</param>
    /// <param name="green">The green color.</param>
    /// <param name="blue">The blue color.</param>
    /// <exception cref="NoxTypeValidationException"></exception>
    public static Color From(byte alpha, byte red, byte green, byte blue)
    {
        var color = System.Drawing.Color.FromArgb(alpha, red, green, blue);
        return From(color);
    }

    /// <summary>
    /// Creates a new instance of <see cref="Color"/> object
    /// </summary>
    /// <param name="name">The origin value to create the <see cref="Color"/> with</param>
    /// <returns></returns>
    /// <exception cref="NoxTypeValidationException"></exception>
    public static Color FromName(string name)
    {
        var color = System.Drawing.Color.FromName(name);
        return From(color);
    }

    /// <summary>
    /// Validates the <see cref="Color"/> object.
    /// </summary>
    /// <returns>A validation result indicating whether the <see cref="Color"/> object is valid or not.</returns>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (!_hexColorRegex.IsMatch(Value))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Color type with unsupported value '{Value}'."));
        }

        return result;
    }

    /// <summary>
    /// Returns the bytes representation of the color value
    /// </summary>
    /// <returns>The byte representation</returns>
    public byte[] ToBytes()
    {
        var color = ToSystemColor();
        return new[] { color.A, color.R, color.G, color.B };
    }

    /// <summary>
    /// Returns the string representation of the color value, formatted in Hex format string
    /// </summary>
    /// <returns>The string representation</returns>
    public string ToHex()
    {
        var color = ToSystemColor();
        return $"#{color.R:X2}{color.G:X2}{color.B:X2}";
    }

    /// <summary>
    /// Returns the string representation of the color value, formatted in name format string
    /// </summary>
    /// <returns>The string representation</returns>
    public System.Drawing.Color ToSystemColor()
    {
        return ColorTranslator.FromHtml(Value);
    }

    /// <summary>
    /// Returns the string representation of the color value, formatted using the given standard color format string
    /// </summary>
    /// <param name="format">A standard color format string (must be valid for either name, rgb, rgba, hexa or hex, depending on the base type)</param>
    /// <returns>The string representation</returns>
    public string ToString(string format)
    {
        return format.ToLower() switch
        {
            "hexa" => Value,
            "hex" => ToHex(),
            "name" => ToSystemColor().Name,
            "rgb" => ToRgbString(),
            "rgba" => ToRgbaString(),
            _ => ToString(),
        };
    }

    /// <summary>
    /// Returns the string representation of the color value, formatted in RGB format string
    /// </summary>
    /// <returns>The string representation</returns>
    public string ToRgbString()
    {
        var color = ToSystemColor();
        return $"RGB({color.R}, {color.G}, {color.B})";
    }

    /// <summary>
    /// Returns the string representation of the color value, formatted in RGBA format string
    /// </summary>
    /// <returns>The string representation</returns>
    public string ToRgbaString()
    {
        var color = ToSystemColor();
        return $"RGBA({color.R}, {color.G}, {color.B}, {ToProportion(color.A).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)})";
    }

    private static double ToProportion(byte b) => b / (double)Byte.MaxValue;
}
