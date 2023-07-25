using System;
using System.Globalization;
using System.Linq;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Color"/> type and value object. 
/// </summary>
public class Color : ValueObject<byte[], Color>
{
    private byte _alpha { get; set; }
    private byte _red { get; set; }
    private byte _green { get; set; }
    private byte _blue { get; set; }
    
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
        return CreateColor(color);
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
        var color = System.Drawing.Color.FromArgb(byte.MaxValue, red, green, blue);

        return CreateColor(color);
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

        return CreateColor(color);
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

        return CreateColor(color);
    }

    /// <summary>
    /// Creates a new instance of <see cref="Color"/> object
    /// </summary>
    /// <param name="alphadecimal">The origin value to create the <see cref="Color"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Color FromAlphaColor(string alphadecimal)
    {
        return ColorHelper.ConvertFromString(alphadecimal, CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Returns the bytes representation of the color value
    /// </summary>
    /// <returns>The byte representation</returns>
    public byte[] ToBytes() => new byte[] { _alpha, _red, _green, _blue };

    /// <summary>
    /// Returns the string representation of the color value, formatted in Hexadecimal format string
    /// </summary>
    /// <returns>The string representation</returns>
    public string ToHexa() => $"#{_alpha:X2}{_red:X2}{_green:X2}{_blue:X2}";

    /// <summary>
    /// Returns the string representation of the color value, formatted in Hex format string
    /// </summary>
    /// <returns>The string representation</returns>
    public string ToHex() => $"#{_red:X2}{_green:X2}{_blue:X2}";

    /// <summary>
    /// Returns the string representation of the color value, formatted in name format string
    /// </summary>
    /// <returns>The string representation</returns>
    public string ToName()
    {
        var color = System.Drawing.Color.FromArgb(_alpha, _red, _green, _blue);

        var knownColor = KnownColor.Colors.FirstOrDefault(kc => kc.Value.ToArgb() == color.ToArgb());

        return knownColor.Key ?? "UnknownColor";
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"{_alpha},{_red},{_green},{_blue}";
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
            "name" => ToName(),
            "rgb" => ToRgbString(),
            "rgba" => ToRgbaString(),
            _ => ToString(),
        };
    }

    /// <summary>
    /// Returns the string representation of the color value, formatted in RGB format string
    /// </summary>
    /// <returns>The string representation</returns>
    public string ToRgbString() => $"RGB({_red}, {_green}, {_blue})";

    /// <summary>
    /// Returns the string representation of the color value, formatted in RGBA format string
    /// </summary>
    /// <returns>The string representation</returns>
    public string ToRgbaString() => $"RGBA({_red}, {_green}, {_blue}, {ToProportion(_alpha):N2})";
    
    /// <inheritdoc/>
    public override bool Equals(object obj)
    {
        if (!(obj is Color otherColor))
            return false;

        return _red == otherColor._red &&
               _green == otherColor._green &&
               _blue == otherColor._blue &&
               _alpha == otherColor._alpha;
    }
    
    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    private static double ToProportion(byte b) => b / (double)Byte.MaxValue;

    private static Color CreateColor(System.Drawing.Color color)
    {
        var newColor = new Color
        {
            _alpha = color.A,
            _red = color.R,
            _green = color.G,
            _blue = color.B,
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
