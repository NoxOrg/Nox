using Nox.Types.Common;
using System.Collections.Generic;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Length"/> type and value object.
/// </summary>
public class Length : Measurement<Length, LengthUnit>
{
    /// <summary>
    /// Creates a new instance of <see cref="Length"/> object in meters.
    /// </summary>
    /// <param name="value">The value to create the <see cref="Length"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Length FromMeters(QuantityValue value)
        => From(value, LengthUnit.Meter);

    /// <summary>
    /// Creates a new instance of <see cref="Length"/> object in feet.
    /// </summary>
    /// <param name="value">The origin value to create the <see cref="Length"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Length FromFeet(QuantityValue value)
        => From(value, LengthUnit.Foot);

    /// <summary>
    /// Creates a new instance of <see cref="Length"/> object in meters.
    /// </summary>
    /// <param name="value">The value to create the <see cref="Length"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public new static Length From(QuantityValue value)
        => From(value, LengthUnit.Meter);

    private QuantityValue? _meters;

    public QuantityValue ToMeters() => _meters ??= GetMeasurementIn(LengthUnit.Meter);

    private QuantityValue? _feet;

    public QuantityValue ToFeet() => _feet ??= GetMeasurementIn(LengthUnit.Foot);

    protected override IEnumerable<KeyValuePair<string, object>> GetEqualityComponents()
    {
        yield return new KeyValuePair<string, object>(nameof(Value), ToMeters());
    }

    protected override MeasurementConversionFactor<LengthUnit> ResolveUnitConversionFactor(LengthUnit sourceUnit, LengthUnit targetUnit)
        => new LengthConversionFactor(sourceUnit, targetUnit);
}