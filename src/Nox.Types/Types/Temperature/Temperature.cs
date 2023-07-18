using Nox.Types.Common;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Temperature"/> type and value object.
/// </summary>
/// <remarks>Placeholder, needs to be implemented</remarks>
public sealed class Temperature : Measurement<Temperature, TemperatureUnit>
{
    /// <summary>
    /// Absolute zero degrees represented in Celsius.
    /// </summary>
    private const float MinimumValueCelsius = -273.15f;
    /// <summary>
    /// Absolute zero degrees represented in Fahrenheit.
    /// </summary>
    private const float MinimumValueFahrenheit = -459.67f;

    /// <summary>
    /// Creates a new instance of <see cref="Temperature"/> object in <see cref="TemperatureTypeUnit.Celsius"/>.
    /// </summary>
    /// <param name="temperature">The value to create the <see cref="Temperature"/> with.</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Temperature FromCelsius(QuantityValue temperature) => From(temperature, TemperatureUnit.Celsius);

    /// <summary>
    /// Creates a new instance of <see cref="Temperature"/> object in <see cref="TemperatureTypeUnit.Fahrenheit"/>.
    /// </summary>
    /// <param name="temperature">The value to create the <see cref="Temperature"/> with.</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Temperature FromFahrenheit(QuantityValue temperature) => From(temperature, TemperatureUnit.Fahrenheit);

    /// <summary>
    /// Creates a new instance of <see cref="Temperature"/> object in meters.
    /// </summary>
    /// <param name="value">The value to create the <see cref="Temperature"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static new Temperature From(QuantityValue value)
        => From(value, TemperatureUnit.Celsius);

    /// <summary>
    /// /// Validates a <see cref="Temperature"/> object.
    /// </summary>
    /// <returns>true if the <see cref="Temperature"/> value is valid.</returns>
    internal override ValidationResult Validate()
    {
        var result = new ValidationResult();

        if ((Unit == TemperatureUnit.Celsius && Value < MinimumValueCelsius) ||
            (Unit == TemperatureUnit.Fahrenheit && Value < MinimumValueFahrenheit))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), "Temperature cannot be below absolute zero."));
        }

        return result;
    }

    /// <summary>
    /// Converts <see cref="Temperature.TemperatureValue"/> to value in <see cref="TemperatureUnit.Celsius"/>.
    /// </summary>
    /// <returns>TemperatureValue in <see cref="TemperatureUnit.Celsius"/></returns>
    public QuantityValue ToCelsius()
    {
        if (Unit == TemperatureUnit.Celsius)
            return Value;

        var newObject = FromCelsius(((Value - 32) * 5) / 9);

        return newObject.Value;
    }

    /// <summary>
    /// Converts <see cref="Temperature.TemperatureValue"/> to value in <see cref="TemperatureUnit.Fahrenheit"/>.
    /// </summary>
    /// <returns>TemperatureValue in <see cref="TemperatureUnit.Fahrenheit"/></returns>
    public QuantityValue ToFahrenheit()
    {
        if (Unit == TemperatureUnit.Fahrenheit)
            return Value;

        var newObject = FromCelsius((Value * 9 / 5) + 32);

        return newObject.Value;
    }

    protected override IEnumerable<KeyValuePair<string, object>> GetEqualityComponents()
    {
        yield return new KeyValuePair<string, object>(nameof(Value), ToCelsius());
    }

    protected override MeasurementConversionFactor<TemperatureUnit> ResolveUnitConversionFactor(TemperatureUnit sourceUnit, TemperatureUnit targetUnit)
        => new TemperatureConversionFactor(sourceUnit, targetUnit);
}
