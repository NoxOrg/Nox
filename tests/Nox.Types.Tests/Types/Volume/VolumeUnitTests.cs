using FluentAssertions;

namespace Nox.Types.Tests.Types;

public class VolumeUnitTests
{
    [Fact]
    public void VolumeUnit_CubicMeter_ReturnsValidIdNameAndSymbol()
    {
        var cubicMeter = VolumeUnit.CubicMeter;

        cubicMeter.Id.Should().Be(1);
        cubicMeter.Name.Should().Be("CubicMeter");
        cubicMeter.Symbol.Should().Be("m³");
    }

    [Fact]
    public void VolumeUnit_CubicFoot_ReturnsValidIdNameAndSymbol()
    {
        var cubicMeter = VolumeUnit.CubicFoot;

        cubicMeter.Id.Should().Be(2);
        cubicMeter.Name.Should().Be("CubicFoot");
        cubicMeter.Symbol.Should().Be("ft³");
    }
}
