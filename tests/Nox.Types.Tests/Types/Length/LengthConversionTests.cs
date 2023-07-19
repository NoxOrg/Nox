using FluentAssertions;
using Nox.Types.Common;

namespace Nox.Types.Tests.Types;

public class LengthConversionTests
{
    [Fact]
    public void LengthConversion_FromFootToMeter_ReturnsValue()
    {
        var conversion = new LengthConversion(LengthUnit.Foot, LengthUnit.Meter);

        conversion.Calculate.Should().Be(0.30480000033);
    }

    [Fact]
    public void LengthConversion_FromMeterToFoot_ReturnsValue()
    {
        var conversion = new LengthConversion(LengthUnit.Meter, LengthUnit.Foot);

        conversion.Calculate.Should().Be(3.28083989142);
    }

    [Fact]
    public void LengthConversionFactor_WhenMultipliedByQuantityValue_ReturnsValue()
    {
        var conversion = new LengthConversion(LengthUnit.Meter, LengthUnit.Foot);

        var result1 = (QuantityValue)2.5 * conversion.Calculate(1);
        var result2 = conversion.Calculate(1) * (QuantityValue)2.5;

        result1.Should().Be(result2);
        result1.Should().Be(8.20209972855);
    }
}
