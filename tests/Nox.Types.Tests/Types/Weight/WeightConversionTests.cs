using FluentAssertions;
using Nox.Types.Common;

namespace Nox.Types.Tests.Types;

public class WeightConversionTests
{
    [Fact]
    public void WeightConversion_FromPoundToKilogram_ReturnsValue()
    {
        var conversion = new WeightConversion(WeightUnit.Pound, WeightUnit.Kilogram);

        conversion.Calculate(1).Should().Be(0.45359237);
    }

    [Fact]
    public void WeightConversion_FromKilogramToPound_ReturnsValue()
    {
        var conversion = new WeightConversion(WeightUnit.Kilogram, WeightUnit.Pound);

        conversion.Calculate(1).Should().Be(2.20462262);
    }

    [Fact]
    public void WeightConversion_WhenMultipliedByQuantityValue_ReturnsValue()
    {
        var conversion = new WeightConversion(WeightUnit.Kilogram, WeightUnit.Pound);

        var result1 = (QuantityValue)2.5 * conversion.Calculate(1);
        var result2 = conversion.Calculate(1) * (QuantityValue)2.5;

        result1.Should().Be(result2);
        result1.Should().Be(5.51155655);
    }
}
