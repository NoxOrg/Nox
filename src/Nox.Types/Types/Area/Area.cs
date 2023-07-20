using Nox.Types.Common;
using System;
using System.Collections.Generic;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Area"/> type and value object.
/// </summary>
public class Area : Measurement<Area, AreaUnit>
{
    private AreaTypeOptions _areaTypeOptions = new();

    /// <summary>
    /// Creates a new instance of <see cref="Area"/> object in square meters.
    /// </summary>
    /// <param name="value">The value to create the <see cref="Area"/> with</param>
    /// <param name="options">The type options to create the <see cref="Area"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Area FromSquareMeters(QuantityValue value, AreaTypeOptions? options = null)
        => From(value, AreaUnit.SquareMeter, options);

    /// <summary>
    /// Creates a new instance of <see cref="Area"/> object in square feet.
    /// </summary>
    /// <param name="value">The value to create the <see cref="Area"/> with</param>
    /// <param name="options">The type options to create the <see cref="Area"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Area FromSquareFeet(QuantityValue value, AreaTypeOptions? options = null)
        => From(value, AreaUnit.SquareFoot, options);

    /// <summary>
    /// Creates a new instance of <see cref="Area"/> object in square meters.
    /// </summary>
    /// <param name="value">The value to create the <see cref="Area"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public new static Area From(QuantityValue value)
        => FromSquareMeters(value);

    /// <summary>
    /// Creates a new instance of <see cref="Area"/> object with the specified <see cref="AreaUnit"/>.
    /// </summary>
    /// <param name="value">The value to create the <see cref="Area"/> with</param>
    /// <param name="unit">The <see cref="AreaUnit"/> to create the <see cref="Area"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Area From(QuantityValue value, AreaUnit unit, AreaTypeOptions? options = null)
    {
        var newObject = new Area
        {
            Value = Round(value),
            Unit = unit,
            _areaTypeOptions = options ?? new(),
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
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
        var result = base.Validate();

        if (!double.IsNaN((double)Value) && !double.IsInfinity((double)Value))
        {
            var defaultUnit = Enumeration.FromName<AreaUnit>(_areaTypeOptions.Unit.ToString());
            var valueInDefaultUnit = GetMeasurementIn(defaultUnit);

            if(valueInDefaultUnit > _areaTypeOptions.MaxValue)
            {
                result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Area type as value {Value} {Unit} is greater than the specified maximum of {_areaTypeOptions.MaxValue} {defaultUnit}."));
            }

            if(Value >= 0 && valueInDefaultUnit < _areaTypeOptions.MinValue)
            {
                result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Area type as value {Value} {Unit} is lesser than the specified minimum of {_areaTypeOptions.MinValue} {defaultUnit}."));

            }
        }

        return result;
    }

    private QuantityValue? _squareMeters;
    public QuantityValue ToSquareMeters() => _squareMeters ??= GetMeasurementIn(AreaUnit.SquareMeter);

    private QuantityValue? _squareFeet;
    public QuantityValue ToSquareFeet() => _squareFeet ??= GetMeasurementIn(AreaUnit.SquareFoot);

    protected override IEnumerable<KeyValuePair<string, object>> GetEqualityComponents()
    {
        yield return new KeyValuePair<string, object>(nameof(Value), ToSquareMeters());
    }

    protected override MeasurementConversion<AreaUnit> ResolveUnitConversion(AreaUnit sourceUnit, AreaUnit targetUnit)
        => new AreaConversion(sourceUnit, targetUnit);
}