// ReSharper disable once CheckNamespace
using FluentAssertions;

namespace Nox.Types.Tests.Types;

public class TemperatureTests
{
    [Theory]
    [InlineData(25.05, TemperatureTypeUnit.Celsius)]
    [InlineData(86.88, TemperatureTypeUnit.Fahrenheit)]
    public void From_TemperatureUnitSent_ReturnsValue(float value, TemperatureTypeUnit unit)
    {
        var temperature = Temperature.From(value, unit);

        temperature.TemperatureValue.Should().Be(value);
        temperature.Unit.Should().Be(unit);
    }

    [Theory]
    [InlineData(-280, TemperatureTypeUnit.Celsius)]
    [InlineData(-460, TemperatureTypeUnit.Fahrenheit)]
    public void From_TemperatureAbsoluteZero_ThrowsException(float value, TemperatureTypeUnit unit)
    {
        Action comparison = () => Temperature.From(value, unit);

        comparison.Should().Throw<TypeValidationException>();
    }

    [Fact]
    public void FromCelsius_ReturnsValue()
    {
        float value = 32.5F;
        var temperature = Temperature.FromCelsius(value);

        temperature.TemperatureValue.Should().Be(value);
        temperature.Unit.Should().Be(TemperatureTypeUnit.Celsius);
    }

    [Fact]
    public void FromCelsius_TemperatureAbsoluteZero_ThrowsException()
    {
        Action comparison = () => Temperature.FromCelsius(-300);

        comparison.Should().Throw<TypeValidationException>();
    }

    [Fact]
    public void FromFahrenheit_ReturnsValue()
    {
        float value = 90.5F;
        var temperature = Temperature.FromFahrenheit(value);

        temperature.TemperatureValue.Should().Be(value);
        temperature.Unit.Should().Be(TemperatureTypeUnit.Fahrenheit);
    }

    [Fact]
    public void FromFahrenheit_TemperatureAbsoluteZero_ThrowsException()
    {
        Action comparison = () => Temperature.FromFahrenheit(-980);

        comparison.Should().Throw<TypeValidationException>();
    }

    [Fact]
    public void From_DefaultUnit_ReturnsValue()
    {
        float value = 30.8F;
        var temperature = Temperature.FromCelsius(value);

        temperature.TemperatureValue.Should().Be(value);
        temperature.Unit.Should().Be(TemperatureTypeUnit.Celsius);
    }

    [Fact]
    public void From_DefaultUnit_TemperatureAbsoluteZero_ThrowsException()
    {
        Action comparison = () => Temperature.FromCelsius(-300f);

        comparison.Should().Throw<TypeValidationException>();
    }

    [Theory]
    [InlineData(25.05, TemperatureTypeUnit.Celsius, "25.05 C")]
    [InlineData(86.8899, TemperatureTypeUnit.Fahrenheit, "86.89 F")]
    public void ToString_ReturnsValue(float value, TemperatureTypeUnit unit, string expected)
    {
        var temperature = Temperature.From(value, unit);

        temperature.ToString().Should().Be(expected);
    }

    [Theory]
    [InlineData(25.05, TemperatureTypeUnit.Celsius, 25.05)]
    [InlineData(88.5, TemperatureTypeUnit.Fahrenheit, 31.39)]
    public void TemperatureValueToCelsius_ReturnsCorrectValue(float value, TemperatureTypeUnit unit, float expected)
    {
        var temperature = Temperature.From(value, unit);

        temperature.TemperatureValueToCelsius().Should().Be(expected);
    }

    [Theory]
    [InlineData(25.05, TemperatureTypeUnit.Fahrenheit, 25.05)]
    [InlineData(31.39, TemperatureTypeUnit.Celsius, 88.5)]
    public void TemperatureValueToFahrenheit_ReturnsCorrectValue(float value, TemperatureTypeUnit unit, float expected)
    {
        var temperature = Temperature.From(value, unit);

        temperature.TemperatureValueToFahrenheit().Should().Be(expected);
    }

}