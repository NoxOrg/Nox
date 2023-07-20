using Nox.Types.Common;
using System.Collections.Generic;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Weight"/> type and value object.
/// </summary>
public class Weight : Measurement<Weight, WeightUnit>
{
    /// <summary>
    /// Creates a new instance of <see cref="Weight"/> object in kilograms.
    /// </summary>
    /// <param name="value">The value to create the <see cref="Weight"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Weight FromKilograms(QuantityValue value)
        => From(value, WeightUnit.Kilogram);

    /// <summary>
    /// Creates a new instance of <see cref="Weight"/> object in pounds.
    /// </summary>
    /// <param name="value">The origin value to create the <see cref="Weight"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Weight FromPounds(QuantityValue value)
        => From(value, WeightUnit.Pound);

    /// <summary>
    /// Creates a new instance of <see cref="Weight"/> object in kilograms.
    /// </summary>
    /// <param name="value">The origin value to create the <see cref="Weight"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public new static Weight From(QuantityValue value)
        => From(value, WeightUnit.Kilogram);

    private QuantityValue? _kilograms;
    public QuantityValue ToKilograms() => _kilograms ??= GetMeasurementIn(WeightUnit.Kilogram);

    private QuantityValue? _pounds;
    public QuantityValue ToPounds() => _pounds ??= GetMeasurementIn(WeightUnit.Pound);

    protected override IEnumerable<KeyValuePair<string, object>> GetEqualityComponents()
    {
        yield return new KeyValuePair<string, object>(nameof(Value), ToKilograms());
    }

    protected override MeasurementConversion<WeightUnit> ResolveUnitConversion(WeightUnit sourceUnit, WeightUnit targetUnit)
        => new WeightConversion(sourceUnit, targetUnit);
}
