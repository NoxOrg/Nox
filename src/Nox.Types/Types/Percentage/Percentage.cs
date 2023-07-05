using System;
using System.Globalization;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Percentage"/> type and value object.
/// </summary>
public sealed class Percentage : ValueObject<float, Percentage>
{
    private PercentageTypeOptions _percentageTypeOptions = new();

    /// <summary>
    /// Creates a new instance of <see cref="Percentage"/> class with the specified values.
    /// </summary>
    /// <param name="value">The value to create the <see cref="Percentage"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Percentage From(float value, PercentageTypeOptions options)
    {
        var newObject = new Percentage
        {
            Value = value,
            _percentageTypeOptions = options
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        return newObject;
    }

    /// <summary>
    /// Validates a <see cref="Percentage"/> object.
    /// </summary>
    /// <returns>true if the <see cref="Percentage"/> value is valid.</returns>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (Value < _percentageTypeOptions.MinValue && !float.IsNaN(Value) && !float.IsInfinity(Value))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Percentage type as value {Value} is less than than the minimum specified value of {_percentageTypeOptions.MinValue}"));
        }

        if (Value > _percentageTypeOptions.MaxValue && !float.IsNaN(Value) && !float.IsInfinity(Value))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Percentage type a value {Value} is greater than than the maximum specified value of {_percentageTypeOptions.MaxValue}"));
        }

        Value = (float)Math.Round(Value, _percentageTypeOptions.Digits);

        return result;
    }

    public override string ToString()
        => $"{(Value * 100).ToString($"0.{new string('#', _percentageTypeOptions.Digits)}", CultureInfo.InvariantCulture)}%";

    /// <summary>
    /// Returns a string representation of the <see cref="Percentage"/> object using the specified <see cref="IFormatProvider"/>.
    /// </summary>
    /// <param name="formatProvider">The format provider for the length value.</param>
    /// <returns>A string representation of the <see cref="Percentage"/> object with the value formatted using the specified <see cref="IFormatProvider"/>.</returns>
    public string ToString(IFormatProvider formatProvider)
        => $"{Value.ToString(formatProvider)}%";
}
