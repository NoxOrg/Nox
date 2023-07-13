using FluentAssertions;

namespace Nox.Types.Tests.Types;

public class DistanceUnitTests
{
    [Fact]
    public void DistanceUnit_Kilometer_ReturnsValidIdNameAndSymbol()
    {
        var kilometer = DistanceUnit.Kilometer;

        kilometer.Id.Should().Be(1);
        kilometer.Name.Should().Be("Kilometer");
        kilometer.Symbol.Should().Be("km");
    }

    [Fact]
    public void DistanceUnit_Mile_ReturnsValidIdNameAndSymbol()
    {
        var mile = DistanceUnit.Mile;

        mile.Id.Should().Be(2);
        mile.Name.Should().Be("Mile");
        mile.Symbol.Should().Be("mi");
    }
}
