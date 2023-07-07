using System;
using System.Globalization;
using System.Security.Cryptography;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Temperature"/> type and value object.
/// </summary>
/// <remarks>Placeholder, needs to be implemented</remarks>
public sealed class Temperature : ValueObject<(float TemperatureValue, TemperatureTypeUnit Unit), Temperature>
{
    public float TemperatureValue
    {
        get => Value.TemperatureValue;
        private set => Value = (TemperatureValue: value, Value.Unit);
    }
    public TemperatureTypeUnit Unit
    {
        get => Value.Unit;
        private set => Value = (Value.TemperatureValue, Unit: value);
    }

    public Temperature() { Value = (0, TemperatureTypeUnit.Celsius); }

    /// <summary>
    /// Creates a new instance of <see cref="Temperature"/> object in <see cref="TemperatureTypeUnit.Celsius"/>.
    /// </summary>
    /// <param name="value">The value to create the <see cref="Temperature"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Temperature FromCelsius(float temperature) => From(temperature, TemperatureTypeUnit.Celsius);

    /// <summary>
    /// Creates a new instance of <see cref="Temperature"/> object in <see cref="TemperatureTypeUnit.Fahrenheit"/>.
    /// </summary>
    /// <param name="value">The value to create the <see cref="Temperature"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Temperature FromFahrenheit(float temperature) => From(temperature, TemperatureTypeUnit.Fahrenheit);

    /// <summary>
    /// Creates a new instance of <see cref="Temperature"/> object in <see cref="TemperatureTypeUnit.Celsius"/>.
    /// </summary>
    /// <param name="value">The value to create the <see cref="Temperature"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Temperature From(float temperature) => From(temperature, TemperatureTypeUnit.Celsius);

    /// <summary>
    /// Creates a new instance of <see cref="Temperature"/> object in sent TemperatureTypeUnit/>.
    /// </summary>
    /// <param name="value">The value to create the <see cref="Temperature"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static Temperature From(float temperature, TemperatureTypeUnit temperatureTypeUnit)
    {
        var newObject = new Temperature
        {
            Value = (Round(temperature), temperatureTypeUnit),
            Unit = temperatureTypeUnit,
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        return newObject;
    }

    /// <summary>
    /// /// Validates a <see cref="Temperature"/> object.
    /// </summary>
    /// <returns>true if the <see cref="Temperature"/> value is valid.</returns>
    internal override ValidationResult Validate()
    {
        var result = new ValidationResult();

        if ((Value.Unit == TemperatureTypeUnit.Celsius && Value.TemperatureValue < -273.15) ||
            (Value.Unit == TemperatureTypeUnit.Fahrenheit && Value.TemperatureValue < -459.67)) // Absolute zero 
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), "Temperature cannot be below absolute zero."));
        }

        return result;
    }

    /// <summary>
    /// Returns a string representation of the <see cref="Temperature"/> object./>.
    /// </summary>
    /// <returns>A string representation of the <see cref="Temperature"/> object.</returns>
    public override string ToString()
        => $"{TemperatureValue.ToString($"0.{new string('#', 2)}", CultureInfo.InvariantCulture)} {Unit.ToSymbol()}";

    /// <summary>
    /// Converts <see cref="Temperature.TemperatureValue"/> to value in <see cref="TemperatureTypeUnit.Celsius"/>.
    /// </summary>
    /// <returns>TemperatureValue in <see cref="TemperatureTypeUnit.Celsius"/></returns>
    public float TemperatureValueToCelsius()
    {
        if (Unit == TemperatureTypeUnit.Celsius) return TemperatureValue;

        return Round((TemperatureValue - 32) * 5 / 9);
    }

    /// <summary>
    /// Converts <see cref="Temperature.TemperatureValue"/> to value in <see cref="TemperatureTypeUnit.Fahrenheit"/>.
    /// </summary>
    /// <returns>TemperatureValue in <see cref="TemperatureTypeUnit.Fahrenheit"/></returns>
    public float TemperatureValueToFahrenheit()
    {
        if (Unit == TemperatureTypeUnit.Fahrenheit) return TemperatureValue;

        return Round((TemperatureValue * 9 / 5) + 32);
    }

    private static float Round(float value)
        => (float)Math.Round(value, 2);
}
