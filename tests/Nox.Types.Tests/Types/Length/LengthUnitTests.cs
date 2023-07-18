using FluentAssertions;

namespace Nox.Types.Tests.Types;

public class LengthUnitTests
{
    [Fact]
    public void LengthUnit_Meter_ReturnsValidIdNameAndSymbol()
    {
        var meter = LengthUnit.Meter;

        meter.Id.Should().Be(1);
        meter.Name.Should().Be("Meter");
        meter.Symbol.Should().Be("m");
    }

    [Fact]
    public void LengthUnit_Foot_ReturnsValidIdNameAndSymbol()
    {
        var foot = LengthUnit.Foot;

        foot.Id.Should().Be(2);
        foot.Name.Should().Be("Foot");
        foot.Symbol.Should().Be("ft");
    }
}
