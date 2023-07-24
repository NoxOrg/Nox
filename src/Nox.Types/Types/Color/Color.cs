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
    
    public Color()
    {
        Value = new byte[4];
    }

    private bool _isEmpty { get; set; }

    public static Color Empty
    {
        get => new() { _isEmpty = true };
    }

    /// <summary>
    /// Validates a <see cref="Color"/> object.
    /// </summary>
    /// <returns>true if the <see cref="Color"/> value is valid.</returns>
    internal override ValidationResult Validate()
    {
        var result = new ValidationResult();

        if (Value.Length < 1)
            result.Errors.Add(new ValidationFailure(nameof(Value),
                $"Could not create a Nox {nameof(Color)} type as an empty {nameof(Value)} is not allowed."));

        if (Value.Length > 4)
            result.Errors.Add(new ValidationFailure(nameof(Value),
                $"Could not create a Nox {nameof(Color)} type with more than 4 values."));

        return result;
    }

    public static Color From(byte red, byte green, byte blue)
        => From(new byte[] { 0, red, green, blue });

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

    public byte[] ToBytes() => new byte[] { _alpha, _red, _green, _blue };

    public string ToHexa() => $"#{_alpha:X2}{_red:X2}{_green:X2}{_blue:X2}";

    public string ToHex() => $"#{_red:X2}{_green:X2}{_blue:X2}";

    public string ToName()
    {
        var color = System.Drawing.Color.FromArgb(_alpha, _red, _green, _blue);

        var knownColor = KnownColor.Colors.FirstOrDefault(kc => kc.Value.ToArgb() == color.ToArgb());

        return knownColor.Key ?? "UnknownColor";
    }

    public override string ToString()
    {
        return $"{_alpha},{_red},{_green},{_blue}";
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

    public string ToRgbString() => $"RGB({_red}, {_green}, {_blue})";

    public string ToRgbaString() => $"RGBA({_red}, {_green}, {_blue}, {ToProportion(_alpha):N2})";

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
