using Nox.Common;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Area"/> type and value object.
/// </summary>
public class Area : ValueObject<QuantityValue, Area>
{
    private const int QuantityValueDecimalPrecision = 6;
    
    private const long EarthsSurfaceAreaInSquareMeters = 510_072_000_000_000;

    public AreaTypeUnit Unit { get; private set; } = AreaTypeUnit.SquareMeter;

    public Area() { Value = 0; }

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
        => From(value, AreaTypeUnit.SquareFoot);

    /// <summary>
    /// Creates a new instance of <see cref="Area"/> object in square meters.
    /// </summary>
    /// <param name="value">The value to create the <see cref="Area"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public new static Area From(QuantityValue value)
        => From(value, AreaTypeUnit.SquareMeter);

    /// <summary>
    /// Creates a new instance of <see cref="Area"/> with the specified <see cref="AreaTypeUnit"/>
    /// </summary>
    /// <param name="value">The value to create the <see cref="Area"/> with</param>
    /// <param name="unit">The <see cref="AreaTypeUnit"/> to create the <see cref="Area"/> with</param>
    /// <returns></returns>
    /// <exception cref="ValidationException"></exception>
    public static Area From(QuantityValue value, AreaTypeUnit unit)
    {
        var newObject = new Area
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
    /// Validates a <see cref="Area"/> object.
    /// </summary>
    /// <returns>
    /// true if the <see cref="Area"/> value is valid.
    /// </returns>
    internal override ValidationResult Validate()
    {
        var result = Value.Validate();

        if (Value < 0)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Area type as negative area value {Value} is not allowed."));
        }

        if (ToSquareMeters() > EarthsSurfaceAreaInSquareMeters)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Area type as value {Value} is greater than the surface area of the Earth."));
        }

        return result;
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

    protected override IEnumerable<KeyValuePair<string, object>> GetEqualityComponents()
    {
        yield return new KeyValuePair<string, object>(nameof(Value), ToSquareMeters());
    }

    private QuantityValue? _squareMeters;
    public QuantityValue ToSquareMeters() => (_squareMeters ??= GetAreaIn(AreaTypeUnit.SquareMeter));

    private QuantityValue? _squareFeet;
    public QuantityValue ToSquareFeet() => (_squareFeet ??= GetAreaIn(AreaTypeUnit.SquareFoot));

    private QuantityValue GetAreaIn(AreaTypeUnit targetUnit)
    {
        var factor = new Common.MeasurementConversionFactor((MeasurementTypeUnit)Unit, (MeasurementTypeUnit)targetUnit).Value;
        return Round(Value * factor);
    }

    private static QuantityValue Round(QuantityValue value)
        => Math.Round((double)value, QuantityValueDecimalPrecision);
}