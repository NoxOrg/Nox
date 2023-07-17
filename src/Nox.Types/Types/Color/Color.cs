using System;
using System.Globalization;
using System.Linq;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Color"/> type and value object. 
/// </summary>
public class Color : ValueObject<(byte Alpha, byte Red, byte Green, byte Blue), Color>
{
    public Color() { Value = (Alpha = 0, Red = 0, Green = 0, Blue = 0); }

    public byte Alpha
    {
        get => Value.Alpha;
        private set => Value = Value with { Alpha = value };
    }

    public byte Red
    {
        get => Value.Red;
        private set => Value = Value with { Red = value };
    }

    public byte Green
    {
        get => Value.Green;
        private set => Value = Value with { Green = value };
    }

    public byte Blue
    {
        get => Value.Blue;
        private set => Value = Value with { Blue = value };
    }

    public static Color Empty
    {
        get => new();
    }

    /// <summary>
    /// Validates a <see cref="Color"/> object.
    /// </summary>
    /// <returns>true if the <see cref="Color"/> value is valid.</returns>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (System.Drawing.Color.FromArgb(Alpha, Red, Green, Blue).IsEmpty)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Color type as uninitialized color value {Value} is not allowed."));
        }

        return result;
    }

    public static Color From(byte red, byte green, byte blue)
        => From((0, red, green, blue));

    /// <summary>
    /// Creates a new instance of <see cref="Color"/> object
    /// </summary>
    /// <param name="value">The origin value to create the <see cref="Color"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Color FromRgba(byte alpha, byte red, byte green, byte blue)
    {
        var color = System.Drawing.Color.FromArgb(alpha, red, green, blue);

        return CreateColor(color);
    }

    /// <summary>
    /// Creates a new instance of <see cref="Color"/> object
    /// </summary>
    /// <param name="value">The origin value to create the <see cref="Color"/> with</param>
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
    /// <param name="value">The origin value to create the <see cref="Color"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Color FromAlphaColor(string alphadecimal)
    {
        return ColorConverter.ConvertFromString(alphadecimal, CultureInfo.InvariantCulture);
    }

    public byte[] ToBytes() => new byte[] { Alpha, Red, Green, Blue };

    public string ToHexa() => $"#{Alpha:X2}{Red:X2}{Green:X2}{Blue:X2}";

    public string ToHex() => $"#{Red:X2}{Green:X2}{Blue:X2}";

    public string ToName()
    {
        var color = System.Drawing.Color.FromArgb(Alpha, Red, Green, Blue);

        var knownColor = KnownColor.Colors.FirstOrDefault(kc => kc.Value.ToArgb() == color.ToArgb());

        return knownColor.Key ?? "UnknownColor";
    }

    public override string ToString()
    {
        return $"{Alpha},{Red},{Green},{Blue}";
    }

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

    public string ToRgbString() => $"RGB({Red}, {Green}, {Blue})";

    public string ToRgbaString() => $"RGBA({Red}, {Green}, {Blue}, {ToProportion(Alpha):N2})";

    private static double ToProportion(byte b) => b / (double)Byte.MaxValue;

    private static Color CreateColor(System.Drawing.Color color)
    {
        var newColor = new Color
        {
            Alpha = color.A,
            Red = color.R,
            Green = color.G,
            Blue = color.B,
        };

        var validationResult = newColor.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        return newColor;
    }
}
