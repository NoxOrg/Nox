using FluentAssertions;

namespace Nox.Types.Tests.Types;

public class VolumeConversionFactorTests
{
    [Fact]
    public void VolumeConversionFactor_FromCubicFootToCubicMeter_ReturnsValue()
    {
        var factor = new VolumeConversionFactor(VolumeUnit.CubicFoot, VolumeUnit.CubicMeter);

        factor.Value.Should().Be(0.0283168466);
    }

    [Fact]
    public void VolumeConversionFactor_FromCubicMeterToCubicFoot_ReturnsValue()
    {
        var factor = new VolumeConversionFactor(VolumeUnit.CubicMeter, VolumeUnit.CubicFoot);

        factor.Value.Should().Be(35.3146667);
    }

    [Fact]
    public void VolumeConversionFactor_WhenMultipliedByQuantityValue_ReturnsValue()
    {
        var factor = new VolumeConversionFactor(VolumeUnit.CubicMeter, VolumeUnit.CubicFoot);

        var result1 = (QuantityValue)2.5 * factor;
        var result2 = factor * (QuantityValue)2.5;

        result1.Should().Be(result2);
        result1.Should().Be(88.28666675);
    }
}
