using Nox.Types.Common;
using System.Collections.Generic;

namespace Nox.Types;

public class Distance : Measurement<Distance, DistanceUnit>
{
    /// <summary>
    /// Creates a new instance of <see cref="Distance"/> object in kilometers.
    /// </summary>
    /// <param name="value">The value to create the <see cref="Distance"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Distance FromKilometers(QuantityValue value)
        => From(value, DistanceUnit.Kilometer);

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
        => From(value, DistanceUnit.Mile);

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
        => From(value, DistanceUnit.Kilometer);

    private QuantityValue? _kilometers;
    public QuantityValue ToKilometers() => _kilometers ??= GetMeasurementIn(DistanceUnit.Kilometer);

    private QuantityValue? _miles;
    public QuantityValue ToMiles() => _miles ??= GetMeasurementIn(DistanceUnit.Mile);

    protected override IEnumerable<KeyValuePair<string, object>> GetEqualityComponents()
    {
        yield return new KeyValuePair<string, object>(nameof(Value), ToKilometers());
    }

    private static double CalculateDistanceInKilometers(LatLong origin, LatLong destination)
        => new HaversineDistanceCalculator().Calculate(origin, destination);

    protected override MeasurementConversionFactor<DistanceUnit> ResolveUnitConversionFactor(DistanceUnit sourceUnit, DistanceUnit targetUnit)
        => new DistanceConversionFactor(sourceUnit, targetUnit);
}