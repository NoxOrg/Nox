using Nox.Common;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Nox.Types;

public class Distance : ValueObject<QuantityValue, Distance>
{
    private const int QuantityValueDecimalPrecision = 6;

    public DistanceTypeUnit Unit { get; private set; } = DistanceTypeUnit.Kilometer;

    public Distance() { Value = 0; }

    /// <summary>
    /// Creates a new instance of <see cref="Distance"/> object in kilometers.
    /// </summary>
    /// <param name="value">The value to create the <see cref="Distance"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Distance FromKilometers(QuantityValue value)
        => From(value, DistanceTypeUnit.Kilometer);

    /// <summary>
    /// Creates a new instance of <see cref="Distance"/> object in kilometers.
    /// </summary>
    /// <param name="origin">The origin <see cref="LatLong"/> to create the <see cref="Distance"/> with</param>
    /// <param name="destination">The destination <see cref="LatLong"/> to create the <see cref="Distance"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Distance FromKilometers(LatLong origin, LatLong destination)
        => FromKilometers(CalculateDistanceInKilometers(origin, destination));

    /// <summary>
    /// Creates a new instance of <see cref="Distance"/> object in miles.
    /// </summary>
    /// <param name="value">The origin value to create the <see cref="Distance"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Distance FromMiles(QuantityValue value)
        => From(value, DistanceTypeUnit.Mile);

    /// <summary>
    /// Creates a new instance of <see cref="Distance"/> object in miles.
    /// </summary>
    /// <param name="origin">The origin <see cref="LatLong"/> to create the <see cref="Distance"/> with</param>
    /// <param name="destination">The destination <see cref="LatLong"/> to create the <see cref="Distance"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Distance FromMiles(LatLong origin, LatLong destination)
    {
        var distanceInKm = FromKilometers(origin, destination);
        return FromMiles(distanceInKm.ToMiles());
    }

    /// <summary>
    /// Creates a new instance of <see cref="Distance"/> object in kilometers.
    /// </summary>
    /// <param name="value">The value to create the <see cref="Distance"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public new static Distance From(QuantityValue value)
        => From(value, DistanceTypeUnit.Kilometer);

    /// <summary>
    /// Creates a new instance of <see cref="Distance"/> object with the specified <see cref="DistanceTypeUnit"/>.
    /// </summary>
    /// <param name="value">The value to create the <see cref="Distance"/> with</param>
    /// <param name="unit">The <see cref="DistanceTypeUnit"/> to create the <see cref="Distance"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Distance From(QuantityValue value, DistanceTypeUnit unit)
    {
        var newObject = new Distance
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
    /// Validates a <see cref="Distance"/> object.
    /// </summary>
    /// <returns>true if the <see cref="Distance"/> value is valid.</returns>
    internal override ValidationResult Validate()
    {
        var result = Value.Validate();

        if (Value < 0)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Distance type as negative distance value {Value} is not allowed."));
        }

        if (!Enum.IsDefined(typeof(DistanceTypeUnit), Unit))
        {
            result.Errors.Add(new ValidationFailure(nameof(Unit), $"Could not create a Nox Distance type as unit {Unit} is not supported."));
        }

        return result;
    }

    protected override IEnumerable<KeyValuePair<string, object>> GetEqualityComponents()
    {
        yield return new KeyValuePair<string, object>(nameof(Value), ToKilometers());
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

    private QuantityValue? _kilometers;

    public QuantityValue ToKilometers() => (_kilometers ??= GetDistanceIn(DistanceTypeUnit.Kilometer));

    private QuantityValue? _miles;

    public QuantityValue ToMiles() => (_miles ??= GetDistanceIn(DistanceTypeUnit.Mile));

    private QuantityValue GetDistanceIn(DistanceTypeUnit targetUnit)
    {
        var factor = new Common.MeasurementConversionFactor((MeasurementTypeUnit)Unit, (MeasurementTypeUnit)targetUnit).Value;
        return Round(Value * factor);
    }

    private static QuantityValue Round(QuantityValue value)
        => Math.Round((double)value, QuantityValueDecimalPrecision);

    private static double CalculateDistanceInKilometers(LatLong origin, LatLong destination)
        => new HaversineDistanceCalculator().Calculate(origin, destination);
}