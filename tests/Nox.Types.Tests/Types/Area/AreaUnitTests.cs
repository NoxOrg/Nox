using FluentAssertions;

namespace Nox.Types.Tests.Types;

public class AreaUnitTests
{
    [Fact]
    public void AreaUnit_SquareMeter_ReturnsValidIdNameAndSymbol()
    {
        var squareMeter = AreaUnit.SquareMeter;

        squareMeter.Id.Should().Be(1);
        squareMeter.Name.Should().Be("SquareMeter");
        squareMeter.Symbol.Should().Be("m²");
    }

    [Fact]
    public void AreaUnit_SquareFoot_ReturnsValidIdNameAndSymbol()
    {
        var squareFoot = AreaUnit.SquareFoot;

        squareFoot.Id.Should().Be(2);
        squareFoot.Name.Should().Be("SquareFoot");
        squareFoot.Symbol.Should().Be("ft²");
    }
}
