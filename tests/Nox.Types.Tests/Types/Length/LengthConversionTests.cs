using FluentAssertions;
using Nox.Types.Common;

namespace Nox.Types.Tests.Types;

public class LengthConversionTests
{
    [Fact]
    public void LengthConversion_FromFootToMeter_ReturnsValue()
    {
        var conversion = new LengthConversion(LengthUnit.Foot, LengthUnit.Meter);

        conversion.Calculate(1).Should().Be(0.3048m);
    }

    [Fact]
    public void LengthConversion_FromMeterToFoot_ReturnsValue()
    {
        var conversion = new LengthConversion(LengthUnit.Meter, LengthUnit.Foot);

        conversion.Calculate(1).Should().Be(3.2808398950131233595800524934m);
    }

    [Fact]
    public void LengthConversion_WhenMultipliedByQuantityValue_ReturnsValue()
    {
        var conversion = new LengthConversion(LengthUnit.Meter, LengthUnit.Foot);

        var result1 = (QuantityValue)2.5 * conversion.Calculate(1);
        var result2 = conversion.Calculate(1) * (QuantityValue)2.5;

        result1.Should().Be(result2);
        result1.Should().Be(8.202099737532808398950131234m);
    }
}
