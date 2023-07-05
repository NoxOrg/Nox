using System.Collections.Generic;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Volume"/> type and value object.
/// </summary>
public sealed class Volume : Measurement<Volume, VolumeUnit>
{
    /// <summary>
    /// Creates a new instance of <see cref="Volume"/> object in cubic feet.
    /// </summary>
    /// <param name="value">The value to create the <see cref="Volume"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Volume FromCubicFeet(QuantityValue value)
        => From(value, VolumeUnit.CubicFoot);

    /// <summary>
    /// Creates a new instance of <see cref="Volume"/> object in cubic meters.
    /// </summary>
    /// <param name="value">The origin value to create the <see cref="Volume"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Volume FromCubicMeters(QuantityValue value)
        => From(value, VolumeUnit.CubicMeter);

    /// <summary>
    /// Creates a new instance of <see cref="Volume"/> object in cubic meters.
    /// </summary>
    /// <param name="value">The origin value to create the <see cref="Volume"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public new static Volume From(QuantityValue value)
        => From(value, VolumeUnit.CubicMeter);

    private QuantityValue? _cubicFeet;

    public QuantityValue ToCubicFeet() => _cubicFeet ??= GetMeasurementIn(VolumeUnit.CubicFoot);

    private QuantityValue? _cubicMeters;

    public QuantityValue ToCubicMeters() => _cubicMeters ??= GetMeasurementIn(VolumeUnit.CubicMeter);

    protected override IEnumerable<KeyValuePair<string, object>> GetEqualityComponents()
    {
        yield return new KeyValuePair<string, object>(nameof(Value), ToCubicMeters());
    }

    protected override MeasurementConversionFactor<VolumeUnit> ResolveUnitConversionFactor(VolumeUnit sourceUnit, VolumeUnit targetUnit)
        => new VolumeConversionFactor(sourceUnit, targetUnit);
}