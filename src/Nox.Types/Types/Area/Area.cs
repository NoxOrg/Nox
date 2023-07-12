using Nox.Common;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Area"/> type and value object.
/// </summary>
public class Area : Measurement<Area, AreaUnit>
{
    private const long EarthsSurfaceAreaInSquareMeters = 510_072_000_000_000;

    /// <summary>
    /// Creates a new instance of <see cref="Area"/> object in square meters.
    /// </summary>
    /// <param name="value">The value to create the <see cref="Area"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Area FromSquareMeters(QuantityValue value)
        => From(value);

    /// <summary>
    /// Creates a new instance of <see cref="Area"/> object in square feet.
    /// </summary>
    /// <param name="value">The value to create the <see cref="Area"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Area FromSquareFeet(QuantityValue value)
        => From(value, AreaUnit.SquareFoot);

    /// <summary>
    /// Creates a new instance of <see cref="Area"/> object in square meters.
    /// </summary>
    /// <param name="value">The value to create the <see cref="Area"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public new static Area From(QuantityValue value)
        => From(value, AreaUnit.SquareMeter);

    /// <summary>
    /// Validates a <see cref="Area"/> object.
    /// </summary>
    /// <returns>
    /// true if the <see cref="Area"/> value is valid.
    /// </returns>
    internal override ValidationResult Validate()
    {
        var result = Value.Validate();

        if (!double.IsNaN((double)Value) && !double.IsInfinity((double)Value))
        {
            if (Value < 0)
            {
                result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Area type as negative area value {Value} is not allowed."));
            }

            if (ToSquareMeters() > EarthsSurfaceAreaInSquareMeters)
            {
                result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Area type as value {Value} is greater than the surface area of the Earth."));
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

    protected override MeasurementConversionFactor<AreaUnit> ResolveUnitConversionFactor(AreaUnit sourceUnit, AreaUnit targetUnit)
        => new AreaConversionFactor(sourceUnit, targetUnit);
}