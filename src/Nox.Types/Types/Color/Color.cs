using System;
using System.Drawing;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Color"/> type and value object. 
/// </summary>
public class Color : ValueObject<byte[], Color>
{
    private System.Drawing.Color _systemColor { get; set; }

    /// <summary>
    /// Creates a new instance of <see cref="Color"/> object.
    /// </summary>
    public Color()
    {
        Value = new byte[4];
    }

    /// <summary>
    /// Creates a <see cref="Color"/> object from a <see cref="System.Drawing.Color"/>.
    /// </summary>
    /// <param name="color">the color to be parsed.</param>
    public static Color From(System.Drawing.Color color)
    {
        return From(color.A, color.R, color.G, color.B);
    }

    /// <summary>
    /// Creates a new instance of <see cref="Color"/> object.
    /// </summary>
    /// <param name="red">The red color.</param>
    /// <param name="green">The green color.</param>
    /// <param name="blue">The blue color.</param>
    /// <exception cref="TypeValidationException"></exception>
    public static Color From(byte red, byte green, byte blue)
    {
        return From(byte.MaxValue, red, green, blue);
    }

    /// <summary>
    /// Creates a new instance of <see cref="Color"/> object.
    /// </summary>
    /// <param name="alpha">The alpha color.</param>
    /// <param name="red">The red color.</param>
    /// <param name="green">The green color.</param>
    /// <param name="blue">The blue color.</param>
    /// <exception cref="TypeValidationException"></exception>
    public static Color From(byte alpha, byte red, byte green, byte blue)
    {
        var color = System.Drawing.Color.FromArgb(alpha, red, green, blue);
        return CreateFromColor(color);
    }

    /// <summary>
    /// Creates a new instance of <see cref="Color"/> object
    /// </summary>
    /// <param name="name">The origin value to create the <see cref="Color"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Color FromName(string name)
    {
        var color = System.Drawing.Color.FromName(name);
        return CreateFromColor(color);
    }

    /// <summary>
    /// Creates a new instance of <see cref="Color"/> object
    /// </summary>
    /// <param name="alphadecimal">The origin value to create the <see cref="Color"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Color FromAlphaColor(string alphadecimal)
    {
        var colorFromHtml = ColorTranslator.FromHtml(alphadecimal);
        return From(colorFromHtml);
    }

    /// <summary>
    /// Returns the bytes representation of the color value
    /// </summary>
    /// <returns>The byte representation</returns>
    public byte[] ToBytes() => new byte[] { _systemColor.A, _systemColor.R, _systemColor.G, _systemColor.B };

    /// <summary>
    /// Returns the string representation of the color value, formatted in Hexadecimal format string
    /// </summary>
    /// <returns>The string representation</returns>
    public string ToHexa() => $"#{_systemColor.A:X2}{_systemColor.R:X2}{_systemColor.G:X2}{_systemColor.B:X2}";

    /// <summary>
    /// Returns the string representation of the color value, formatted in Hex format string
    /// </summary>
    /// <returns>The string representation</returns>
    public string ToHex() => $"#{_systemColor.R:X2}{_systemColor.G:X2}{_systemColor.B:X2}";

    /// <summary>
    /// Returns the string representation of the color value, formatted in name format string
    /// </summary>
    /// <returns>The string representation</returns>
    public System.Drawing.Color ToSystemColor()
    {
        return _systemColor;
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"{_systemColor.A},{_systemColor.R},{_systemColor.G},{_systemColor.B}";
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
            "hexa" => ToHexa(),
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
    public string ToRgbString() => $"RGB({_systemColor.R}, {_systemColor.G}, {_systemColor.B})";

    /// <summary>
    /// Returns the string representation of the color value, formatted in RGBA format string
    /// </summary>
    /// <returns>The string representation</returns>
    public string ToRgbaString() => $"RGBA({_systemColor.R}, {_systemColor.G}, {_systemColor.B}, {_systemColor.A})";

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        if (!(obj is Color otherColor))
            return false;

        return _systemColor.R == otherColor._systemColor.R &&
               _systemColor.G == otherColor._systemColor.G &&
               _systemColor.B == otherColor._systemColor.B &&
               _systemColor.A == otherColor._systemColor.A;
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    private static Color CreateFromColor(System.Drawing.Color color)
    {
        var newColor = new Color
        {
            _systemColor = color
        };

        newColor.Value = new byte[] { color.A, color.R, color.G, color.B };

        var validationResult = newColor.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        return newColor;
    }
}
