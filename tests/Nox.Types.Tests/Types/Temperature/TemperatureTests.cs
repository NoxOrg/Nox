// ReSharper disable once CheckNamespace
using FluentAssertions;

namespace Nox.Types.Tests.Types;

public class TemperatureTests
{
    [Fact]
    public void From_TemperatureUnitSent_Celsius_ReturnsValue()
    {
        var value = 25.05;
        var temperature = Temperature.From(value, TemperatureUnit.Celsius);

        temperature.Value.Should().Be(value);
        temperature.Unit.Should().Be(TemperatureUnit.Celsius);
    }

    [Fact]
    public void From_TemperatureUnitSent_Fahrenheit_ReturnsValue()
    {
        var value = 86.88;
        var temperature = Temperature.From(value, TemperatureUnit.Fahrenheit);

        temperature.Value.Should().Be(value);
        temperature.Unit.Should().Be(TemperatureUnit.Fahrenheit);
    }

    [Fact]
    public void From_TemperatureNan_ThrowsException()
    {
        Action comparison = () => Temperature.From(double.NaN, TemperatureUnit.Fahrenheit);

        comparison.Should().Throw<TypeValidationException>();
    }

    [Fact]
    public void FromCelsius_ReturnsValue()
    {
        double value = 32.5;
        var temperature = Temperature.FromCelsius(value);

        temperature.Value.Should().Be(value);
        temperature.Unit.Should().Be(TemperatureUnit.Celsius);
    }

    [Fact]
    public void FromFahrenheit_ReturnsValue()
    {
        double value = 90.5;
        var temperature = Temperature.FromFahrenheit(value);

        temperature.Value.Should().Be(value);
        temperature.Unit.Should().Be(TemperatureUnit.Fahrenheit);
    }

    [Fact]
    public void From_DefaultUnit_ReturnsValue()
    {
        double value = 30.8;
        var temperature = Temperature.FromCelsius(value);

        temperature.Value.Should().Be(value);
        temperature.Unit.Should().Be(TemperatureUnit.Celsius);
    }

    [Fact]
    public void ToString_Celsius_ReturnsValue()
    {
        var value = 25.05;
        var temperature = Temperature.From(value, TemperatureUnit.Celsius);

        temperature.ToString().Should().Be("25.05 C");
    }

    [Fact]
    public void ToString_Fahrenheit_ReturnsValue()
    {
        var value = 25.05;
        var temperature = Temperature.From(value, TemperatureUnit.Fahrenheit);

        temperature.ToString().Should().Be("25.05 F");
    }

    [Fact]
    public void TemperatureConversion_CelsiusToCelsius_ReturnsCorrectValue()
    {
        var temperature = Temperature.From(25.05, TemperatureUnit.Celsius);

        temperature.ToCelsius().Should().Be(25.05);
    }

    [Theory]
    [InlineData(87.89, 31.05)]
    [InlineData(212, 100)]
    public void TemperatureConversion_FahrenheitToCelsius_ReturnsCorrectValue(double temperatureFahrenheit, double temperatureCelsius)
    {
        var temperatureObject = Temperature.From(temperatureFahrenheit, TemperatureUnit.Fahrenheit);

        temperatureObject.ToCelsius().Should().Be(temperatureCelsius);
    }

    [Theory]
    [InlineData(87.89, 31.05)]
    [InlineData(212, 100)]
    public void TemperatureConversion_CelsiusToFahrenheit_ReturnsCorrectValue(double temperatureFahrenheit, double temperatureCelsius)
    {
        var temperature = Temperature.From(temperatureCelsius, TemperatureUnit.Celsius);

        temperature.ToFahrenheit().Should().Be(temperatureFahrenheit);
    }
}