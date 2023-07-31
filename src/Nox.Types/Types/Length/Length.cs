using Nox.Types.Common;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Length"/> type and value object.
/// </summary>
public class Length : ValueObject<QuantityValue, Length>
{
    public const int QuantityValueDecimalPrecision = 6;

    private LengthTypeOptions _lengthTypeOptions = new();
    private LengthUnit _lengthUnit = null!;

    public LengthTypeUnit Unit { get; private init; }


    /// <summary>
    /// Creates a new instance of <see cref="Length"/>.
    /// </summary>
    /// <param name="value">The value to create the <see cref="Length"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public new static Length From(QuantityValue value)
        => From(value, new LengthTypeOptions());

    /// <summary>
    /// Creates a new instance of <see cref="Length"/> object in specified unit.
    /// </summary>
    /// <param name="value">The value to create the <see cref="Length"/> with</param>
    /// <param name="unit">The unit to create the <see cref="Length"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Length From(QuantityValue value, LengthTypeUnit unit)
        => From(value, new LengthTypeOptions() { Units = unit });

    /// <summary>
    /// Creates a new instance of <see cref="Length"/> object with specified options.
    /// </summary>
    /// <param name="value">The value to create the <see cref="Length"/> with</param>
    /// <param name="options">The options to create the <see cref="Length"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Length From(QuantityValue value, LengthTypeOptions options)
    {
        var newObject = new Length
        {
            Value = value.Round(QuantityValueDecimalPrecision),
            Unit = options.Units,
            _lengthUnit = Enumeration.ParseFromName<LengthUnit>(options.Units.ToString()),
            _lengthTypeOptions = options,
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        return newObject;
    }

    /// <summary>
    /// Validates a <see cref="Length"/> object.
    /// </summary>
    /// <returns>
    /// true if the <see cref="Length"/> value is valid.
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
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Length type as negative length value {Value} is not allowed."));
        }

        if (Value >= 0 && Value < _lengthTypeOptions.MinValue)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Length type as value {Value} {_lengthUnit} is lesser than the specified minimum of {_lengthTypeOptions.MinValue} {_lengthUnit}."));

        }

        if (Value > _lengthTypeOptions.MaxValue)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Length type as value {Value} {_lengthUnit} is greater than the specified maximum of {_lengthTypeOptions.MaxValue} {_lengthUnit}."));
        }

        return result;
    }

    protected override IEnumerable<KeyValuePair<string, object>> GetEqualityComponents()
    {
        yield return new KeyValuePair<string, object>(nameof(Value), ToMeters());
    }

    public static Length FromDatabase(QuantityValue lengthValue, LengthTypeUnit lengthUnit)
    {
        return new Length
        {
            Value = lengthValue,
            Unit = lengthUnit
        };
    }

    /// <inheritdocs />
    public override string ToString()
        => $"{Value.ToString(CultureInfo.InvariantCulture)} {_lengthUnit}";

    /// <summary>
    /// Returns a string representation of the <see cref="Length"/> object using the specified <see cref="IFormatProvider"/>.
    /// </summary>
    /// <param name="formatProvider">The format provider for the length value.</param>
    /// <returns>A string representation of the <see cref="Length"/> object with the value formatted using the specified <see cref="IFormatProvider"/>.</returns>
    public string ToString(IFormatProvider formatProvider)
        => $"{Value.ToString(formatProvider)} {_lengthUnit}";

    private QuantityValue? _meters;
    public QuantityValue ToMeters() => _meters ??= GetValueIn(LengthUnit.Meter);

    private QuantityValue? _Feet;
    public QuantityValue ToFeet() => _Feet ??= GetValueIn(LengthUnit.Foot);

    private QuantityValue GetValueIn(LengthUnit targetUnit)
    {
        var conversion = new LengthConversion(_lengthUnit, targetUnit);
        return conversion.Calculate(Value).Round(QuantityValueDecimalPrecision);
    }
}