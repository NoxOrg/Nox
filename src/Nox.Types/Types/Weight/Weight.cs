using Nox.Enums;
using Nox.TypeOptions;
using Nox.Types.Common;

using System;
using System.Collections.Generic;
using System.Globalization;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Weight"/> type and value object.
/// </summary>
public class Weight : ValueObject<QuantityValue, Weight>
{
    public const int QuantityValueDecimalPrecision = 6;

    private WeightTypeOptions _weightTypeOptions = new();
    private WeightUnit _weightUnit = null!;

    private WeightTypeUnit _unit;
    public WeightTypeUnit Unit
    {
        get => _unit;
        private init { _unit = value; _weightUnit = Enumeration.ParseFromName<WeightUnit>(_unit.ToString()); }
    }

    /// <summary>
    /// Creates a new instance of <see cref="Weight"/> object.
    /// </summary>
    /// <param name="value">The value to create the <see cref="Weight"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public new static Weight From(QuantityValue value)
        => From(value, new WeightTypeOptions());

    /// <summary>
    /// Creates a new instance of <see cref="Weight"/> object in specified unit.
    /// </summary>
    /// <param name="value">The value to create the <see cref="Weight"/> with</param>
    /// <param name="unit">The unit to create the <see cref="Weight"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Weight From(QuantityValue value, WeightTypeUnit unit)
        => From(value, new WeightTypeOptions() { Units = unit });

    /// <summary>
    /// Creates a new instance of <see cref="Weight"/> object with specified options.
    /// </summary>
    /// <param name="value">The value to create the <see cref="Weight"/> with</param>
    /// <param name="options">The options to create the <see cref="Weight"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Weight From(QuantityValue value, WeightTypeOptions options)
    {
        var newObject = new Weight
        {
            Value = value.Round(QuantityValueDecimalPrecision),
            Unit = options.Units,
            _weightTypeOptions = options,
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        return newObject;
    }

    /// <summary>
    /// Validates a <see cref="Weight"/> object.
    /// </summary>
    /// <returns>
    /// true if the <see cref="Weight"/> value is valid.
    /// </returns>
    internal override ValidationResult Validate()
    {
        var result = Value.Validate();

        if (double.IsNaN((double)Value) || double.IsInfinity((double)Value))
        {
            return result;
        }

        if (Value < 0)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Weight type as negative weight value {Value} is not allowed."));
        }

        if (Value >= 0 && Value < _weightTypeOptions.MinValue)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Weight type as value {Value} {_weightUnit} is lesser than the specified minimum of {_weightTypeOptions.MinValue} {_weightUnit}."));

        }

        if (Value > _weightTypeOptions.MaxValue)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Weight type as value {Value} {_weightUnit} is greater than the specified maximum of {_weightTypeOptions.MaxValue} {_weightUnit}."));
        }

        return result;
    }

    public static Weight FromDatabase(QuantityValue weightValue, WeightTypeUnit weightUnit)
    {
        return new Weight
        {
            Value = weightValue,
            Unit = weightUnit
        };
    }

    public override string ToString()
        => $"{Value.ToString($"0.{new string('#', QuantityValueDecimalPrecision)}", CultureInfo.InvariantCulture)} {_weightUnit}";

    /// <summary>
    /// Returns a string representation of the <see cref="TValueObject"/> object using the specified <see cref="IFormatProvider"/>.
    /// </summary>
    /// <param name="formatProvider">The format provider for the measurement value.</param>
    /// <returns>A string representation of the <see cref="TValueObject"/> object with the value formatted using the specified <see cref="IFormatProvider"/>.</returns>
    public string ToString(IFormatProvider formatProvider)
        => $"{Value.ToString(formatProvider)} {_weightUnit}";

    private QuantityValue? _kilograms;
    public QuantityValue ToKilograms() => _kilograms ??= GetValueIn(WeightUnit.Kilogram);

    private QuantityValue? _pounds;
    public QuantityValue ToPounds() => _pounds ??= GetValueIn(WeightUnit.Pound);

    private QuantityValue GetValueIn(WeightUnit targetUnit)
    {
        var conversion = new WeightConversion(_weightUnit, targetUnit);
        return conversion.Calculate(Value).Round(QuantityValueDecimalPrecision);
    }

    protected override IEnumerable<KeyValuePair<string, object>> GetEqualityComponents()
    {
        yield return new KeyValuePair<string, object>(nameof(Value), ToKilograms());
    }
}
