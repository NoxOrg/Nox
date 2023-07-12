using FluentAssertions;

namespace Nox.Types.Tests.Types;

public class LengthConversionFactorTests
{
    [Fact]
    public void LengthConversionFactor_FromFootToMeter_ReturnsValue()
    {
        var factor = new LengthConversionFactor(LengthUnit.Foot, LengthUnit.Meter);

        factor.Value.Should().Be(0.30480000033);
    }

    [Fact]
    public void LengthConversionFactor_FromMeterToFoot_ReturnsValue()
    {
        var factor = new LengthConversionFactor(LengthUnit.Meter, LengthUnit.Foot);

        factor.Value.Should().Be(3.28083989142);
    }

    [Fact]
    public void LengthConversionFactor_WhenMultipliedByQuantityValue_ReturnsValue()
    {
        var factor = new LengthConversionFactor(LengthUnit.Meter, LengthUnit.Foot);

        var result1 = (QuantityValue)2.5 * factor;
        var result2 = factor * (QuantityValue)2.5;

        result1.Should().Be(result2);
        result1.Should().Be(8.20209972855);
    }
}
