using FluentAssertions;

namespace Nox.Types.Tests.Types;

public class WeightUnitTests
{
    [Fact]
    public void WeightUnit_Kilogram_ReturnsValidIdNameAndSymbol()
    {
        var meter = WeightUnit.Kilogram;

        meter.Id.Should().Be(1);
        meter.Name.Should().Be("Kilogram");
        meter.Symbol.Should().Be("kg");
    }

    [Fact]
    public void WeightUnit_Pound_ReturnsValidIdNameAndSymbol()
    {
        var foot = WeightUnit.Pound;

        foot.Id.Should().Be(2);
        foot.Name.Should().Be("Pound");
        foot.Symbol.Should().Be("lb");
    }
}
