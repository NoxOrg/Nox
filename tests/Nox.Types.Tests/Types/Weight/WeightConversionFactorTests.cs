using FluentAssertions;
using Nox.Types.Common;

namespace Nox.Types.Tests.Types;

public class WeightConversionFactorTests
{
    [Fact]
    public void WeightConversionFactor_FromPoundToKilogram_ReturnsValue()
    {
        var factor = new WeightConversionFactor(WeightUnit.Pound, WeightUnit.Kilogram);

        factor.Value.Should().Be(0.45359237);
    }

    [Fact]
    public void WeightConversionFactor_FromKilogramToPound_ReturnsValue()
    {
        var factor = new WeightConversionFactor(WeightUnit.Kilogram, WeightUnit.Pound);

        factor.Value.Should().Be(2.20462262);
    }

    [Fact]
    public void WeightConversionFactor_WhenMultipliedByQuantityValue_ReturnsValue()
    {
        var factor = new WeightConversionFactor(WeightUnit.Kilogram, WeightUnit.Pound);

        var result1 = (QuantityValue)2.5 * factor;
        var result2 = factor * (QuantityValue)2.5;

        result1.Should().Be(result2);
        result1.Should().Be(5.51155655);
    }
}
