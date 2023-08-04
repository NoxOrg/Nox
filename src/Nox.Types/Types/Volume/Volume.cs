using System;
using System.Collections.Generic;
using System.Globalization;
using Nox.Types.Common;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Volume"/> type and value object.
/// </summary>
public class Volume : ValueObject<QuantityValue, Volume>
{
    public const ushort QuantityValueDecimalPrecision = 6;

    private VolumeTypeOptions _volumeTypeOptions = new();
    private readonly VolumeTypeUnit _unit;
    private readonly VolumeUnit _volumeUnit = null!;

    public VolumeTypeUnit Unit
    {
        get => _unit;
        private init
        {
            _unit = value;
            _volumeUnit = Enumeration.ParseFromName<VolumeUnit>(_unit.ToString());
        }
    }

    /// <inheritdocs />
    public override string ToString() => ToString(CultureInfo.InvariantCulture);

    /// <summary>
    /// Returns a string representation of the <see cref="Volume"/> object using the specified <see cref="IFormatProvider"/>.
    /// </summary>
    /// <param name="formatProvider">The format provider for the volume value.</param>
    /// <returns>A string representation of the <see cref="Volume"/> object with the value formatted using the specified <see cref="IFormatProvider"/>.</returns>
    public string ToString(IFormatProvider formatProvider) => $"{Value.ToString(formatProvider)} {_volumeUnit}";

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
    public static Volume From(QuantityValue value, VolumeUnit unit)
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

        if (double.IsInfinity((double)Value))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value),
                $"Could not create a Nox {nameof(Volume)} type as value Infinity is not allowed."));
            return result;
        }

        if (Value < 0 || double.IsNaN((double)Value))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value),
                $"Could not create a Nox {nameof(Volume)} type as negative value {Value} is not allowed."));
        }


        if (Value >= 0 && Value < _volumeTypeOptions.MinValue)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value),
                $"Could not create a Nox Volume type as value {Value} {_volumeUnit} is lesser than the specified minimum of {_volumeTypeOptions.MinValue} {_volumeUnit}."));
        }

        if (Value > _volumeTypeOptions.MaxValue)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value),
                $"Could not create a Nox Volume type as value {Value} {_volumeUnit} is greater than the specified maximum of {_volumeTypeOptions.MaxValue} {_volumeUnit}."));
        }

        return result;
    }

    protected override IEnumerable<KeyValuePair<string, object>> GetEqualityComponents()
    {
        yield return new KeyValuePair<string, object>(nameof(Value), ToCubicMeters());
    }

    /// <summary>
    /// Creates a new instance of <see cref="Volume"/> from a database value.
    /// It does not validate the value and it is for internal use only.
    /// </summary>
    /// <param name="volumeValue">Value to create a <see cref="Volume"/>.</param>
    /// <param name="volumeUnit">Unit to create a <see cref="Volume"/>.</param>
    /// <returns></returns>
    public static Volume FromDatabase(QuantityValue volumeValue, VolumeTypeUnit volumeUnit)
    {
        return new Volume
        {
            Value = volumeValue,
            Unit = volumeUnit
        };
    }

    private QuantityValue? _cubicFeet;

    public QuantityValue ToCubicFeet() => _cubicFeet ??= GetValueIn(VolumeUnit.CubicFoot);

    private QuantityValue? _cubicMeters;

    public QuantityValue ToCubicMeters() => _cubicMeters ??= GetValueIn(VolumeUnit.CubicMeter);

    private QuantityValue GetValueIn(VolumeUnit targetUnit)
    {
        var conversion = new VolumeConversion(_volumeUnit, targetUnit);
        return conversion.Calculate(Value).Round(QuantityValueDecimalPrecision);
    }
}