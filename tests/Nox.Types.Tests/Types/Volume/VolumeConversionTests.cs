using FluentAssertions;
using Nox.Types.Common;

namespace Nox.Types.Tests.Types;

public class VolumeConversionTests
{
    [Fact]
    public void VolumeConversion_FromCubicFootToCubicMeter_ReturnsValue()
    {
        var conversion = new VolumeConversion(VolumeUnit.CubicFoot, VolumeUnit.CubicMeter);

        conversion.Calculate(1).Should().Be(0.0283168466);
    }

    [Fact]
    public void VolumeConversion_FromCubicMeterToCubicFoot_ReturnsValue()
    {
        var conversion = new VolumeConversion(VolumeUnit.CubicMeter, VolumeUnit.CubicFoot);

        conversion.Calculate(1).Should().Be(35.3146667);
    }

    [Fact]
    public void VolumeConversion_WhenMultipliedByQuantityValue_ReturnsValue()
    {
        var conversion = new VolumeConversion(VolumeUnit.CubicMeter, VolumeUnit.CubicFoot);

        var result1 = (QuantityValue)2.5 * conversion.Calculate(1);
        var result2 = conversion.Calculate(1) * (QuantityValue)2.5;

        result1.Should().Be(result2);
        result1.Should().Be(88.28666675);
    }
}
