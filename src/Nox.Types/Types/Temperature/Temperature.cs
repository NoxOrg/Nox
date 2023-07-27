using Nox.Types.Common;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Temperature"/> type and value object.
/// </summary>
/// <remarks>Placeholder, needs to be implemented</remarks>
public class Temperature : ValueObject<QuantityValue, Temperature>
{
    public const int QuantityValueDecimalPrecision = 2;
    private TemperatureTypeOptions _temperatureTypeOptions = new();
    public TemperatureTypeUnit Unit { get; private init; }

    /// <summary>
    /// Creates a new instance of <see cref="Temperature"/> object in <see cref="TemperatureTypeUnit.Celsius"/>.
    /// </summary>
    /// <param name="value">The value of <see cref="Temperature"/></param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public new static Temperature From(QuantityValue value)
    {
        return From(value, new TemperatureTypeOptions());
    }

    /// <summary>
    /// Creates a new instance of <see cref="Temperature"/> object in sent <see cref="TemperatureTypeUnit"/>.
    /// </summary>
    /// <param name="value">The value of <see cref="Temperature"/></param>
    /// <param name="temperatureUnit">The unit of <see cref="Temperature"/></param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Temperature From(QuantityValue value, TemperatureTypeUnit temperatureUnit)
    {
        return From(value, new TemperatureTypeOptions() { Units = temperatureUnit });
    }

    /// <summary>
    /// Creates a new instance of <see cref="Temperature"/> object in sent <see cref="TemperatureTypeOptions"/>.
    /// </summary>
    /// <param name="value">The value of <see cref="Temperature"/></param>
    /// <param name="options">The options of type <see cref="TemperatureTypeOptions"/></param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Temperature From(QuantityValue value, TemperatureTypeOptions options)
    {
        var newObject = new Temperature
        {
            Value = value.Round(QuantityValueDecimalPrecision),
            Unit = options.Units,
            _temperatureTypeOptions = options,
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        return newObject;
    }

    /// <summary>
    /// Creates a new instance of <see cref="Temperature"/> with parameters sent from database.
    /// </summary>
    /// <param name="temperatureValue">Value read in DB</param>
    /// <param name="temperatureUnit">Unit in which object was persist in DB</param>
    /// <returns>New instance of <see cref="Temperature"/></returns>
    public static Temperature FromDatabase(decimal temperatureValue, TemperatureTypeUnit temperatureUnit)
    {
        return new Temperature
        {
            Value = temperatureValue,
            Unit = temperatureUnit
        };
    }

    /// <summary>
    /// Validates a <see cref="Temperature"/> object.
    /// </summary>
    /// <returns>
    /// true if the <see cref="Temperature"/> value is valid.
    /// </returns>
    internal override ValidationResult Validate()
    {
        var result = Value.Validate();

        if (!Enumeration.TryParseFromName<TemperatureUnit>(_temperatureTypeOptions.PersistAs.ToString(), out var defaultUnit))
        {
            result.Errors.Add(new ValidationFailure(nameof(TemperatureTypeOptions), $"Temperature does not support to be persisted {_temperatureTypeOptions.PersistAs}!"));
            return result;
        }

        if (!Enumeration.TryParseFromName<TemperatureUnit>(_temperatureTypeOptions.Units.ToString(), out defaultUnit))
        {
            result.Errors.Add(new ValidationFailure(nameof(TemperatureTypeOptions), $"Temperature does not support {_temperatureTypeOptions.Units}!"));
            return result;
        }

        return result;
    }

    private QuantityValue? _temperatureCelsius;

    /// <summary>
    /// Converts value in <see cref="TemperatureUnit.Celsius"/>.
    /// </summary>
    /// <returns><see cref="QuantityValue"/> in <see cref="TemperatureUnit.Celsius"/></returns>
    public QuantityValue ToCelsius() => _temperatureCelsius ??= GetMeasurementIn(TemperatureUnit.Celsius);

    private QuantityValue? _temperatureFahrenheit;

    /// <summary>
    /// Converts value in <see cref="TemperatureUnit.Fahrenheit"/>.
    /// </summary>
    /// <returns><see cref="QuantityValue"/> in <see cref="TemperatureUnit.Fahrenheit"/></returns>
    public QuantityValue ToFahrenheit() => _temperatureFahrenheit ??= GetMeasurementIn(TemperatureUnit.Fahrenheit);

    public override string ToString()
        => $"{Value.ToString($"0.{new string('#', QuantityValueDecimalPrecision)}", CultureInfo.InvariantCulture)} {Enumeration.ParseFromName<TemperatureUnit>(Unit.ToString()).Symbol}";

    /// <summary>
    /// Returns a string representation of the <see cref="TValueObject"/> object using the specified <see cref="IFormatProvider"/>.
    /// </summary>
    /// <param name="formatProvider">The format provider for the measurement value.</param>
    /// <returns>A string representation of the <see cref="TValueObject"/> object with the value formatted using the specified <see cref="IFormatProvider"/>.</returns>
    public string ToString(IFormatProvider formatProvider)
        => $"{Value.ToString(formatProvider)} {Enumeration.ParseFromName<TemperatureUnit>(Unit.ToString()).Symbol}";

    protected override IEnumerable<KeyValuePair<string, object>> GetEqualityComponents()
    {
        yield return new KeyValuePair<string, object>(nameof(Value), ToCelsius());
    }

    protected QuantityValue GetMeasurementIn(TemperatureUnit targetUnit)
    {
        var conversion = ResolveUnitConversion(Enumeration.ParseFromName<TemperatureUnit>(Unit.ToString()), targetUnit);
        return conversion.Calculate(Value).Round(QuantityValueDecimalPrecision);
    }

    protected MeasurementConversion<TemperatureUnit> ResolveUnitConversion(TemperatureUnit sourceUnit, TemperatureUnit targetUnit)
        => new TemperatureConversion(sourceUnit, targetUnit);
}
