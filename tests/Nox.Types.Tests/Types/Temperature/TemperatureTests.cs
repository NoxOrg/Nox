// ReSharper disable once CheckNamespace
using FluentAssertions;

namespace Nox.Types.Tests.Types;

public class TemperatureTests
{
    [Fact]
    public void From_TemperatureUnitSent_Celsius_ReturnsValue()
    {
        var value = 25.05;
        var temperature = Temperature.From(value, TemperatureTypeUnit.Celsius);

        temperature.Value.Should().Be(value);
        temperature.Unit.Should().Be(TemperatureTypeUnit.Celsius);
    }

    [Fact]
    public void From_TemperatureUnitSent_Fahrenheit_ReturnsValue()
    {
        var value = 86.88;
        var temperature = Temperature.From(value, TemperatureTypeUnit.Fahrenheit);

        temperature.Value.Should().Be(value);
        temperature.Unit.Should().Be(TemperatureTypeUnit.Fahrenheit);
    }

    [Fact]
    public void From_TemperatureNan_ThrowsException()
    {
        Action comparison = () => Temperature.From(double.NaN, TemperatureTypeUnit.Fahrenheit);

        comparison.Should().Throw<TypeValidationException>();
    }

    [Fact]
    public void From_WithOptions_Celsius_ReturnsValue()
    {
        double value = 32.5;
        var options = new TemperatureTypeOptions() { Units = TemperatureTypeUnit.Celsius };
        var temperature = Temperature.From(value, options);

        temperature.Value.Should().Be(value);
        temperature.Unit.Should().Be(TemperatureTypeUnit.Celsius);
    }

    [Fact]
    public void From_WithOptions_Fahrenheit_ReturnsValue()
    {
        double value = 90.5;
        var options = new TemperatureTypeOptions() { Units = TemperatureTypeUnit.Fahrenheit };
        var temperature = Temperature.From(value, options);

        temperature.Value.Should().Be(value);
        temperature.Unit.Should().Be(TemperatureTypeUnit.Fahrenheit);
    }

    [Fact]
    public void From_DefaultOptions_ReturnsValue()
    {
        double value = 30.8;
        var temperature = Temperature.From(value);

        temperature.Value.Should().Be(value);
        temperature.Unit.Should().Be(TemperatureTypeUnit.Celsius);
    }

    [Fact]
    public void ToString_Celsius_ReturnsValue()
    {
        var value = 25.05;
        var temperature = Temperature.From(value, TemperatureTypeUnit.Celsius);

        temperature.ToString().Should().Be("25.05 C");
    }

    [Fact]
    public void ToString_Fahrenheit_ReturnsValue()
    {
        var value = 25.05;
        var temperature = Temperature.From(value, TemperatureTypeUnit.Fahrenheit);

        temperature.ToString().Should().Be("25.05 F");
    }

    [Fact]
    public void TemperatureConversion_CelsiusToCelsius_ReturnsCorrectValue()
    {
        var temperature = Temperature.From(25.05, TemperatureTypeUnit.Celsius);

        temperature.ToCelsius().Should().Be(25.05);
    }

    [Theory]
    [InlineData(87.89, 31.05)]
    [InlineData(212, 100)]
    public void TemperatureConversion_FahrenheitToCelsius_ReturnsCorrectValue(double temperatureFahrenheit, double temperatureCelsius)
    {
        var temperatureObject = Temperature.From(temperatureFahrenheit, TemperatureTypeUnit.Fahrenheit);

        temperatureObject.ToCelsius().Should().Be(temperatureCelsius);
    }

    [Theory]
    [InlineData(87.89, 31.05)]
    [InlineData(212, 100)]
    public void TemperatureConversion_CelsiusToFahrenheit_ReturnsCorrectValue(double temperatureFahrenheit, double temperatureCelsius)
    {
        var temperature = Temperature.From(temperatureCelsius, TemperatureTypeUnit.Celsius);

        temperature.ToFahrenheit().Should().Be(temperatureFahrenheit);
    }
}