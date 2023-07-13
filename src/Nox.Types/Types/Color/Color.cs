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
        private set => Value = (Alpha: value, Red: Value.Red, Green: Value.Green, Blue: Value.Blue);
    }

    public byte Red
    {
        get => Value.Red;
        private set => Value = (Alpha: Value.Alpha, Red: value, Green: Value.Green, Blue: Value.Blue);
    }

    public byte Green
    {
        get => Value.Green;
        private set => Value = (Alpha: Value.Alpha, Red: Value.Red, Green: value, Blue: Value.Blue);
    }

    public byte Blue
    {
        get => Value.Blue;
        private set => Value = (Alpha: Value.Alpha, Red: Value.Red, Green: Value.Green, Blue: value);
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

        var newObject = new Color
        {
            Alpha = color.A,
            Red = color.R,
            Green = color.G,
            Blue = color.B,
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        return newObject;
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

        var newObject = new Color
        {
            Alpha = color.A,
            Red = color.R,
            Green = color.G,
            Blue = color.B,
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        return newObject;
    }


    /// <summary>
    /// Creates a new instance of <see cref="Color"/> object
    /// </summary>
    /// <param name="value">The origin value to create the <see cref="Color"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Color FromAlphaColor(string alphadecimal)
    {
        alphadecimal = alphadecimal.TrimStart('#');

        string alpha = alphadecimal.Substring(0, 2);
        string red = alphadecimal.Substring(2, 2);
        string green = alphadecimal.Substring(4, 2);
        string blue = alphadecimal.Substring(6, 2);

        int a = int.Parse(alpha, System.Globalization.NumberStyles.HexNumber);
        int r = int.Parse(red, System.Globalization.NumberStyles.HexNumber);
        int g = int.Parse(green, System.Globalization.NumberStyles.HexNumber);
        int b = int.Parse(blue, System.Globalization.NumberStyles.HexNumber);

        var color = System.Drawing.Color.FromArgb(a, r, g, b);

        var newObject = new Color
        {
            Alpha = color.A,
            Red = color.R,
            Green = color.G,
            Blue = color.B,
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        return newObject;
    }

    public byte[] ToBytes() => new byte[] { Alpha, Red, Green, Blue };

    public string ToHex() => $"#{Alpha:X2}{Red:X2}{Green:X2}{Blue:X2}";

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
            "hex" => ToHex(),
            "name" => ToName(),
            _ => ToString(),
        };
    }
}
