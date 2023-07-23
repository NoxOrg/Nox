using System.Globalization;

namespace Nox.Types;

/// <summary>
/// Month value object that represents a month of the year.
/// </summary>
public class Month : ValueObject<byte, Month>
{
    /// <summary>
    /// The minimum valid month value.
    /// </summary>
    private const byte MinMonthValue = 1;

    /// <summary>
    /// The maximum valid month value.
    /// </summary>
    private const byte MaxMonthValue = 12;

    /// <summary>
    /// Validates the <see cref="Month"/> object.
    /// </summary>
    /// <returns>A validation result indicating whether the <see cref="Month"/> object is valid or not.</returns>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (Value is < MinMonthValue or > MaxMonthValue)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Month type with unsupported value '{Value}'. The value must be between {MinMonthValue} and {MaxMonthValue}."));
        }
        return result;
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return Value.ToString("00");
    }


    /// <summary>
    /// Returns the abbreviated month name of the specified <see cref="Month"/> value.
    /// <param name="cultureInfo">Culture to use for the month name.</param>
    /// </summary>
    /// <returns>The abbreviated month name of the specified <see cref="Month"/> value.</returns>
    public string ToAbbreviatedMonthName(CultureInfo? cultureInfo = null)
    {
        return cultureInfo is null ? CultureInfo.InvariantCulture.DateTimeFormat.GetAbbreviatedMonthName(Value) : cultureInfo.DateTimeFormat.GetAbbreviatedMonthName(Value);
    }
    
    /// <summary>
    /// Returns the full month name of the specified <see cref="Month"/> value.
    /// <param name="cultureInfo">Culture to use for the month name.</param>
    /// </summary>
    /// <returns>The full month name of the specified <see cref="Month"/> value.</returns>
    public string ToMonthName(CultureInfo? cultureInfo = null)
    {
        return cultureInfo is null ? CultureInfo.InvariantCulture.DateTimeFormat.GetMonthName(Value) : cultureInfo.DateTimeFormat.GetMonthName(Value);
    }
}
