using Nox.Types.Common;
using System.Collections.Generic;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Temperature"/> type and value object.
/// </summary>
/// <remarks>Placeholder, needs to be implemented</remarks>
public sealed class Temperature : Measurement<Temperature, TemperatureUnit>
{

    /// <summary>
    /// Creates a new instance of <see cref="Temperature"/> object in <see cref="TemperatureUnit.Celsius"/>.
    /// </summary>
    /// <param name="temperature">The value to create the <see cref="Temperature"/> with.</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Temperature FromCelsius(QuantityValue temperature) => From(temperature, TemperatureUnit.Celsius);

    /// <summary>
    /// Creates a new instance of <see cref="Temperature"/> object in <see cref="TemperatureUnit.Fahrenheit"/>.
    /// </summary>
    /// <param name="temperature">The value to create the <see cref="Temperature"/> with.</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Temperature FromFahrenheit(QuantityValue temperature) => From(temperature, TemperatureUnit.Fahrenheit);

    /// <summary>
    /// Creates a new instance of <see cref="Temperature"/> object in celsius.
    /// </summary>
    /// <param name="value">The value to create the <see cref="Temperature"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public new static Temperature From(QuantityValue value)
        => From(value, TemperatureUnit.Celsius);

    /// <summary>
    /// /// Validates a <see cref="Temperature"/> object.
    /// </summary>
    /// <returns>true if the <see cref="Temperature"/> value is valid.</returns>
    internal override ValidationResult Validate()
    {
        return Value.Validate();
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

    protected override IEnumerable<KeyValuePair<string, object>> GetEqualityComponents()
    {
        yield return new KeyValuePair<string, object>(nameof(Value), ToCelsius());
    }

    protected override MeasurementConversion<TemperatureUnit> ResolveUnitConversion(TemperatureUnit sourceUnit, TemperatureUnit targetUnit)
        => new TemperatureConversion(sourceUnit, targetUnit);
}
