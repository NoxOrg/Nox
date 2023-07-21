using Nox.Types.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using YamlDotNet.Core.Tokens;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Area"/> type and value object.
/// </summary>
public class Area : ValueObject<QuantityValue, Area> 
{
    private const int QuantityValueDecimalPrecision = 6;

    private AreaTypeOptions _areaTypeOptions = new();
    public AreaTypeUnit AreaTypeUnit { get; private init;}

    /// <summary>
    /// Creates a new instance of <see cref="Area"/> object in square meters.
    /// </summary>
    /// <param name="value">The value to create the <see cref="Area"/> with</param>
    /// <param name="options">The type options to create the <see cref="Area"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Area FromSquareMeters(QuantityValue value, AreaTypeOptions? options = null)
    {
        options ??= new();

        return From(value, AreaTypeUnit.SquareMeter, options);
    }

    /// <summary>
    /// Creates a new instance of <see cref="Area"/> object in square feet.
    /// </summary>
    /// <param name="value">The value to create the <see cref="Area"/> with</param>
    /// <param name="options">The type options to create the <see cref="Area"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Area FromSquareFeet(QuantityValue value, AreaTypeOptions? options = null)
    {
        options ??= new();

        return From(value, AreaTypeUnit.SquareFoot, options);
    }
        

    /// <summary>
    /// Creates a new instance of <see cref="Area"/> object in square meters.
    /// </summary>
    /// <param name="value">The value to create the <see cref="Area"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public new static Area From(QuantityValue value)
    {
        var options = new AreaTypeOptions();

        return From(value, options.PersistAs, options);
    }

    public static Area From(QuantityValue value, AreaTypeUnit areaUnit) => From(value, areaUnit, new());

    public static Area From(QuantityValue value,AreaTypeUnit areaUnit, AreaTypeOptions options)
    {
        var newObject = new Area
        {
            Value = value.Round(QuantityValueDecimalPrecision),
            AreaTypeUnit = areaUnit,
            _areaTypeOptions = options,
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        return newObject;
    }
    public static Area FromDatabase(double areaValue, AreaTypeUnit areaUnit)
    {
        return new Area
        {
            Value = areaValue,
            AreaTypeUnit = areaUnit
        };
    }

    /// <summary>
    /// Validates a <see cref="Area"/> object.
    /// </summary>
    /// <returns>
    /// true if the <see cref="Area"/> value is valid.
    /// </returns>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (double.IsNaN((double)Value) || double.IsInfinity((double)Value))
        {
            return result;
        }

        if (!Enumeration.TryParseFromName<AreaUnit>(_areaTypeOptions.PersistAs.ToString(), out var defaultUnit))
        {
            result.Errors.Add(new ValidationFailure(nameof(AreaTypeOptions), $"Area does not support to be persisted {_areaTypeOptions.PersistAs}!"));
            return result;
        }

        var valueInDefaultUnit = GetMeasurementIn(defaultUnit);

        if (valueInDefaultUnit > _areaTypeOptions.MaxValue)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Area type as value {Value} {AreaTypeUnit} is greater than the specified maximum of {_areaTypeOptions.MaxValue} {defaultUnit}."));
        }

        if (Value >= 0 && valueInDefaultUnit < _areaTypeOptions.MinValue)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Area type as value {Value} {AreaTypeUnit} is lesser than the specified minimum of {_areaTypeOptions.MinValue} {defaultUnit}."));

        }

        return result;
    }

    public override string ToString()
        => $"{Value.ToString($"0.{new string('#', QuantityValueDecimalPrecision)}", CultureInfo.InvariantCulture)} {AreaTypeUnit}";

    /// <summary>
    /// Returns a string representation of the <see cref="TValueObject"/> object using the specified <see cref="IFormatProvider"/>.
    /// </summary>
    /// <param name="formatProvider">The format provider for the measurement value.</param>
    /// <returns>A string representation of the <see cref="TValueObject"/> object with the value formatted using the specified <see cref="IFormatProvider"/>.</returns>
    public string ToString(IFormatProvider formatProvider)
        => $"{Value.ToString(formatProvider)} {AreaTypeUnit}";

    private QuantityValue? _squareMeters;
    public QuantityValue ToSquareMeters() => _squareMeters ??= GetMeasurementIn(AreaUnit.SquareMeter);

    private QuantityValue? _squareFeet;
    public QuantityValue ToSquareFeet() => _squareFeet ??= GetMeasurementIn(AreaUnit.SquareFoot);

    protected override IEnumerable<KeyValuePair<string, object>> GetEqualityComponents()
    {
        yield return new KeyValuePair<string, object>(nameof(Value), ToSquareMeters());
    }

    protected QuantityValue GetMeasurementIn(AreaUnit targetUnit)
    {
        var conversion = ResolveUnitConversion(Enumeration.ParseFromName<AreaUnit>(AreaTypeUnit.ToString()), targetUnit);
        return conversion.Calculate(Value).Round(QuantityValueDecimalPrecision);
    }
    protected MeasurementConversion<AreaUnit> ResolveUnitConversion(AreaUnit sourceUnit, AreaUnit targetUnit)
        => new AreaConversion(sourceUnit, targetUnit);

    
}