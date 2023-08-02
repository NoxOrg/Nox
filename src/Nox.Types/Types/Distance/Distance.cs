using Nox.Types.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Distance"/> type and value object.
/// </summary>
public class Distance : ValueObject<QuantityValue, Distance>
{
    internal const int QuantityValueDecimalPrecision = 6;

    private DistanceTypeOptions _distanceTypeOptions = new();
    private DistanceUnit _distanceUnit = null!;

    private DistanceTypeUnit _unit;
    public DistanceTypeUnit Unit
    {
        get => _unit;
        private init { _unit = value; _distanceUnit = Enumeration.ParseFromName<DistanceUnit>(_unit.ToString()); }
    }

    /// <summary>
    /// Creates a new instance of <see cref="Distance"/>.
    /// </summary>
    /// <param name="value">The value to create the <see cref="Distance"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public new static Distance From(QuantityValue value)
        => From(value, new DistanceTypeOptions());

    /// <summary>
    /// Creates a new instance of <see cref="Distance"/> object in specified unit.
    /// </summary>
    /// <param name="value">The value to create the <see cref="Distance"/> with</param>
    /// <param name="unit">The unit to create the <see cref="Distance"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Distance From(QuantityValue value, DistanceTypeUnit unit)
        => From(value, new DistanceTypeOptions() { Units = unit });

    /// <summary>
    /// Creates a new instance of <see cref="Distance"/>.
    /// </summary>
    /// <param name="origin">The origin <see cref="LatLong"/> to create the <see cref="Distance"/> with</param>
    /// <param name="destination">The destination <see cref="LatLong"/> to create the <see cref="Distance"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Distance From(LatLong origin, LatLong destination)
        => From(origin, destination, new DistanceTypeOptions());

    /// <summary>
    /// Creates a new instance of <see cref="Distance"/>.
    /// </summary>
    /// <param name="origin">The origin <see cref="LatLong"/> to create the <see cref="Distance"/> with</param>
    /// <param name="destination">The destination <see cref="LatLong"/> to create the <see cref="Distance"/> with</param>
    /// <param name="unit">The <see cref="DistanceTypeUnit"/> to create the <see cref="Distance"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Distance From(LatLong origin, LatLong destination, DistanceTypeUnit unit) 
        => From(origin, destination, new DistanceTypeOptions { Units = unit });

    /// <summary>
    /// Creates a new instance of <see cref="Distance"/>.
    /// </summary>
    /// <param name="origin">The origin <see cref="LatLong"/> to create the <see cref="Distance"/> with</param>
    /// <param name="destination">The destination <see cref="LatLong"/> to create the <see cref="Distance"/> with</param>
    /// <param name="options">The <see cref="DistanceTypeOptions"/> to create the <see cref="Distance"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Distance From(LatLong origin, LatLong destination, DistanceTypeOptions options)
    {
        var distanceValue = new HaversineDistanceCalculator().Calculate(origin, destination, options.Units);
        return From(distanceValue, options);
    }

    /// <summary>
    /// Creates a new instance of <see cref="Distance"/> object with specified options.
    /// </summary>
    /// <param name="value">The value to create the <see cref="Distance"/> with</param>
    /// <param name="options">The options to create the <see cref="Distance"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Distance From(QuantityValue value, DistanceTypeOptions options)
    {
        var newObject = new Distance
        {
            Value = value.Round(QuantityValueDecimalPrecision),
            Unit = options.Units,
            _distanceTypeOptions = options,
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        return newObject;
    }

    /// <summary>
    /// Validates a <see cref="Distance"/> object.
    /// </summary>
    /// <returns>
    /// true if the <see cref="Distance"/> value is valid.
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
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Distance type as negative distance value {Value} is not allowed."));
        }

        if (Value >= 0 && Value < _distanceTypeOptions.MinValue)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Distance type as value {Value} {_distanceUnit} is lesser than the specified minimum of {_distanceTypeOptions.MinValue} {_distanceUnit}."));

        }

        if (Value > _distanceTypeOptions.MaxValue)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Distance type as value {Value} {_distanceUnit} is greater than the specified maximum of {_distanceTypeOptions.MaxValue} {_distanceUnit}."));
        }

        return result;
    }

    protected override IEnumerable<KeyValuePair<string, object>> GetEqualityComponents()
    {
        yield return new KeyValuePair<string, object>(nameof(Value), ToKilometers());
    }

    public static Distance FromDatabase(QuantityValue distanceValue, DistanceTypeUnit distanceUnit)
    {
        return new Distance
        {
            Value = distanceValue,
            Unit = distanceUnit
        };
    }

    /// <inheritdocs />
    public override string ToString()
        => $"{Value.ToString($"0.{new string('#', QuantityValueDecimalPrecision)}", CultureInfo.InvariantCulture)} {_distanceUnit}";

    /// <summary>
    /// Returns a string representation of the <see cref="Distance"/> object using the specified <see cref="IFormatProvider"/>.
    /// </summary>
    /// <param name="formatProvider">The format provider for the distance value.</param>
    /// <returns>A string representation of the <see cref="Distance"/> object with the value formatted using the specified <see cref="IFormatProvider"/>.</returns>
    public string ToString(IFormatProvider formatProvider)
        => $"{Value.ToString(formatProvider)} {_distanceUnit}";

    private QuantityValue? _kilometers;
    public QuantityValue ToKilometers() => _kilometers ??= GetValueIn(DistanceUnit.Kilometer);

    private QuantityValue? _miles;
    public QuantityValue ToMiles() => _miles ??= GetValueIn(DistanceUnit.Mile);

    private QuantityValue GetValueIn(DistanceUnit targetUnit)
    {
        var conversion = new DistanceConversion(_distanceUnit, targetUnit);
        return conversion.Calculate(Value).Round(QuantityValueDecimalPrecision);
    }        
}