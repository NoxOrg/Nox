using Nox.Types.Common;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Area"/> type and value object.
/// </summary>
public class Area : ValueObject<QuantityValue, Area>
{
    public const int QuantityValueDecimalPrecision = 6;

    private AreaTypeOptions _areaTypeOptions = new();
    private AreaUnit _areaUnit = null!;

    private AreaTypeUnit _unit;
    public AreaTypeUnit Unit
    {
        get => _unit;
        private init { _unit = value; _areaUnit = SmartEnumeration.ParseFromName<AreaUnit>(_unit.ToString()); }
    }


    /// <summary>
    /// Creates a new instance of <see cref="Area"/>.
    /// </summary>
    /// <param name="value">The value to create the <see cref="Area"/> with</param>
    /// <returns></returns>
    /// <exception cref="NoxTypeValidationException"></exception>
    public new static Area From(QuantityValue value)
        => From(value, new AreaTypeOptions());

    /// <summary>
    /// Creates a new instance of <see cref="Area"/> object in specified unit.
    /// </summary>
    /// <param name="value">The value to create the <see cref="Area"/> with</param>
    /// <param name="unit">The unit to create the <see cref="Area"/> with</param>
    /// <returns></returns>
    /// <exception cref="NoxTypeValidationException"></exception>
    public static Area From(QuantityValue value, AreaTypeUnit unit)
        => From(value, new AreaTypeOptions() { Units = unit });

    /// <summary>
    /// Creates a new instance of <see cref="Area"/> object with specified options.
    /// </summary>
    /// <param name="value">The value to create the <see cref="Area"/> with</param>
    /// <param name="options">The options to create the <see cref="Area"/> with</param>
    /// <returns></returns>
    /// <exception cref="NoxTypeValidationException"></exception>
    public static Area From(QuantityValue value, AreaTypeOptions options)
    {
        var newObject = new Area
        {
            Value = value.Round(QuantityValueDecimalPrecision),
            Unit = options.Units,
            _areaTypeOptions = options,
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new NoxTypeValidationException(validationResult.Errors);
        }

        return newObject;
    }

    /// <summary>
    /// Validates a <see cref="Area"/> object.
    /// </summary>
    /// <returns>
    /// true if the <see cref="Area"/> value is valid.
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
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Area type as negative area value {Value} is not allowed."));
        }

        if (Value >= 0 && Value < _areaTypeOptions.MinValue)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Area type as value {Value} {_areaUnit} is lesser than the specified minimum of {_areaTypeOptions.MinValue} {_areaUnit}."));

        }

        if (Value > _areaTypeOptions.MaxValue)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Area type as value {Value} {_areaUnit} is greater than the specified maximum of {_areaTypeOptions.MaxValue} {_areaUnit}."));
        }

        return result;
    }

    protected override IEnumerable<KeyValuePair<string, object>> GetEqualityComponents()
    {
        yield return new KeyValuePair<string, object>(nameof(Value), ToSquareMeters()); // Assert equality with certain decimal precision?
    }

    public static Area FromDatabase(QuantityValue areaValue, AreaTypeUnit areaUnit)
    {
        return new Area
        {
            Value = areaValue,
            Unit = areaUnit
        };
    }

    /// <inheritdocs />
    public override string ToString()
        => $"{Value.ToString(CultureInfo.InvariantCulture)} {_areaUnit}";

    /// <summary>
    /// Returns a string representation of the <see cref="Area"/> object using the specified <see cref="IFormatProvider"/>.
    /// </summary>
    /// <param name="formatProvider">The format provider for the area value.</param>
    /// <returns>A string representation of the <see cref="Area"/> object with the value formatted using the specified <see cref="IFormatProvider"/>.</returns>
    public string ToString(IFormatProvider formatProvider)
        => $"{Value.ToString(formatProvider)} {_areaUnit}";

    private QuantityValue? _squareMeters;
    public QuantityValue ToSquareMeters() => _squareMeters ??= GetValueIn(AreaUnit.SquareMeter);

    private QuantityValue? _squareFeet;
    public QuantityValue ToSquareFeet() => _squareFeet ??= GetValueIn(AreaUnit.SquareFoot);

    private QuantityValue GetValueIn(AreaUnit targetUnit)
    {
        var conversion = new AreaConversion(_areaUnit, targetUnit);
        return conversion.Calculate(Value).Round(QuantityValueDecimalPrecision);
    }
}