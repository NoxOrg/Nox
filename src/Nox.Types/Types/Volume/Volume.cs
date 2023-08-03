using System;
using System.Collections.Generic;
using Nox.Types.Common;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Volume"/> type and value object.
/// </summary>
public class Volume : Measurement<Volume, VolumeUnit>
{
    public const ushort QuantityValueDecimalPrecision = 6;

    private VolumeTypeOptions _volumeTypeOptions = new();
    private readonly VolumeTypeUnit _unit;

    public new VolumeTypeUnit Unit
    {
        get => _unit;
        private init
        {
            _unit = value;
            base.Unit = Enumeration.ParseFromName<VolumeUnit>(_unit.ToString());
        }
    }

    /// <summary>
    /// Creates a new instance of <see cref="Volume"/> object in cubic meters.
    /// </summary>
    /// <param name="value">The origin value to create the <see cref="Volume"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public new static Volume From(QuantityValue value)
        => From(value, new VolumeTypeOptions());

    /// <summary>
    /// Creates a new instance of <see cref="Volume"/> object in specified unit.
    /// </summary>
    /// <param name="value">Value to create a <see cref="Volume"/>.</param>
    /// <param name="unit">Unit to create a <see cref="Volume"/>.</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public new static Volume From(QuantityValue value, VolumeUnit unit)
        => From(value, new VolumeTypeOptions { Unit = Enum.Parse<VolumeTypeUnit>(unit.Name) });

    /// <summary>
    /// Creates a new instance of <see cref="Volume"/> object in specified unit.
    /// </summary>
    /// <param name="value">Value to create a <see cref="Volume"/>.</param>
    /// <param name="unit">Unit to create a <see cref="Volume"/>.</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Volume From(QuantityValue value, VolumeTypeUnit unit)
        => From(value, new VolumeTypeOptions { Unit = unit });

    //     public static TValueObject From(QuantityValue value, TUnitType unit)

    /// <summary>
    /// Creates a new instance of <see cref="Volume"/> object with specified options.
    /// </summary>
    /// <param name="value">Value to create a <see cref="Volume"/>.</param>
    /// <param name="options">Options to create a <see cref="Volume"/>.</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Volume From(QuantityValue value, VolumeTypeOptions options)
    {
        var newObject = new Volume
        {
            Value = value.Round(QuantityValueDecimalPrecision),
            Unit = options.Unit,
            _volumeTypeOptions = options,
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        return newObject;
    }

    /// <summary>
    /// Validates a <see cref="Volume"/> object.
    /// </summary>
    /// <returns>
    /// True if the <see cref="Volume"/> value is valid.
    /// </returns>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (double.IsNaN((double)Value) || double.IsInfinity((double)Value))
        {
            return result;
        }

        if (Value >= 0 && Value < _volumeTypeOptions.MinValue)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value),
                $"Could not create a Nox Volume type as value {Value} {base.Unit} is lesser than the specified minimum of {_volumeTypeOptions.MinValue} {base.Unit}."));
        }

        if (Value > _volumeTypeOptions.MaxValue)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value),
                $"Could not create a Nox Volume type as value {Value} {base.Unit} is greater than the specified maximum of {_volumeTypeOptions.MaxValue} {base.Unit}."));
        }

        return result;
    }

    protected override IEnumerable<KeyValuePair<string, object>> GetEqualityComponents()
    {
        yield return new KeyValuePair<string, object>(nameof(Value), ToCubicMeters());
    }

    public static Volume FromDatabase(QuantityValue volumeValue, VolumeTypeUnit volumeUnit)
    {
        return new Volume
        {
            Value = volumeValue,
            Unit = volumeUnit
        };
    }

    private QuantityValue? _cubicFeet;

    public QuantityValue ToCubicFeet() => _cubicFeet ??= GetMeasurementIn(VolumeUnit.CubicFoot);

    private QuantityValue? _cubicMeters;

    public QuantityValue ToCubicMeters() => _cubicMeters ??= GetMeasurementIn(VolumeUnit.CubicMeter);

    protected override MeasurementConversion<VolumeUnit> ResolveUnitConversion(VolumeUnit sourceUnit, VolumeUnit targetUnit)
        => new VolumeConversion(sourceUnit, targetUnit);
}