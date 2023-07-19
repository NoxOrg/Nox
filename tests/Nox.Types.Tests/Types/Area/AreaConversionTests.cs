using FluentAssertions;
using Nox.Types.Common;

namespace Nox.Types.Tests.Types;

public class AreaConversionTests
{
    [Fact]
    public void AreaConversion_FromSquareFootToSquareMeter_ReturnsValue()
    {
        var conversion = new AreaConversion(AreaUnit.SquareFoot, AreaUnit.SquareMeter);

        conversion.Calculate.Should().Be(0.09290304);
    }

    [Fact]
    public void AreaConversion_FromSquareMeterToSquareFoot_ReturnsValue()
    {
        var conversion = new AreaConversion(AreaUnit.SquareMeter, AreaUnit.SquareFoot);

        conversion.Calculate(8).Should().Be(86.11128336);
    }
}
