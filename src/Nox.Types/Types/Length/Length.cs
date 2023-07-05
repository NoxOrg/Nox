using Nox.Common;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Length"/> type and value object.
/// </summary>
public sealed class Length : ValueObject<QuantityValue, Length>
{
    private const int QuantityValueDecimalPrecision = 6;

    public LengthTypeUnit Unit { get; private set; } = LengthTypeUnit.Meter;

    public Length() { Value = 0; }

    /// <summary>
    /// Creates a new instance of <see cref="Length"/> object in meters.
    /// </summary>
    /// <param name="value">The value to create the <see cref="Length"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Length FromMeters(QuantityValue value)
        => From(value, LengthTypeUnit.Meter);

    /// <summary>
    /// Creates a new instance of <see cref="Length"/> object in feet.
    /// </summary>
    /// <param name="value">The origin value to create the <see cref="Length"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Length FromFeet(QuantityValue value)
        => From(value, LengthTypeUnit.Foot);

    /// <summary>
    /// Creates a new instance of <see cref="Length"/> object in meters.
    /// </summary>
    /// <param name="value">The value to create the <see cref="Length"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public new static Length From(QuantityValue value)
        => From(value, LengthTypeUnit.Meter);

    /// <summary>
    /// Creates a new instance of <see cref="Length"/> object with the specified <see cref="LengthTypeUnit"/>.
    /// </summary>
    /// <param name="value">The value to create the <see cref="Length"/> with</param>
    /// <param name="unit">The <see cref="LengthTypeUnit"/> to create the <see cref="Length"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Length From(QuantityValue value, LengthTypeUnit unit)
    {
        var newObject = new Length
        {
            Value = Round(value),
            Unit = unit,
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
    /// <returns>true if the <see cref="Length"/> value is valid.</returns>
    internal override ValidationResult Validate()
    {
        var result = Value.Validate();

        if (Value < 0 && !double.IsNaN((double)Value) && !double.IsInfinity((double)Value))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Length type as negative length value {Value} is not allowed."));
        }

        if (!Enum.IsDefined(typeof(LengthTypeUnit), Unit))
        {
            result.Errors.Add(new ValidationFailure(nameof(Unit), $"Could not create a Nox Length type as unit {Unit} is not supported."));
        }

        return result;
    }

    protected override IEnumerable<KeyValuePair<string, object>> GetEqualityComponents()
    {
        yield return new KeyValuePair<string, object>(nameof(Value), ToMeters());
    }

    public override string ToString()
        => $"{Value.ToString($"0.{new string('#', QuantityValueDecimalPrecision)}", CultureInfo.InvariantCulture)} {Unit.ToSymbol()}";

    /// <summary>
    /// Returns a string representation of the <see cref="Length"/> object using the specified <see cref="IFormatProvider"/>.
    /// </summary>
    /// <param name="formatProvider">The format provider for the length value.</param>
    /// <returns>A string representation of the <see cref="Length"/> object with the value formatted using the specified <see cref="IFormatProvider"/>.</returns>
    public string ToString(IFormatProvider formatProvider)
        => $"{Value.ToString(formatProvider)} {Unit.ToSymbol()}";

    private QuantityValue? _meters;

    public QuantityValue ToMeters()
        => (_meters ??= GetLengthIn(LengthTypeUnit.Meter));

    private QuantityValue? _feet;

    public QuantityValue ToFeet()
        => (_feet ??= GetLengthIn(LengthTypeUnit.Foot));

    private QuantityValue GetLengthIn(LengthTypeUnit targetUnit)
    {
        var factor = new Common.MeasurementConversionFactor((MeasurementTypeUnit)Unit, (MeasurementTypeUnit)targetUnit).Value;
        return Round(Value * factor);
    }

    private static QuantityValue Round(QuantityValue value)
        => Math.Round((double)value, QuantityValueDecimalPrecision);
}