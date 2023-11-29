using System.Globalization;
using System.Runtime.CompilerServices;

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
    /// Integer value of the month.
    /// </summary>
    private int? _value;
    
    /// <summary>
    /// Creates a new instance of the value object from a given value.
    /// </summary>
    /// <param name="value">The value to be used for the value object.</param>
    /// <returns>The newly created value object instance.</returns>
    /// <exception cref="NoxTypeValidationException">Thrown when the validation of the value object fails.</exception>
    public static Month From(int value)
    {
        var month = new Month() { Value = (byte)value, _value = value};
        
        var validationResult = month.Validate();
        if(!validationResult.IsValid)
        {
            throw new NoxTypeValidationException(validationResult.Errors);
        }

        return month;
    }

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
        
        if ( _value is < MinMonthValue or > MaxMonthValue)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Month type with unsupported value '{_value}'. The value must be between {MinMonthValue} and {MaxMonthValue}."));
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
