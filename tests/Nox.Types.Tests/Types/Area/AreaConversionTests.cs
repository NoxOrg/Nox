using FluentAssertions;
using Nox.Types.Common;

namespace Nox.Types.Tests.Types;

public class AreaConversionTests
{
    [Fact]
    public void AreaConversion_FromSquareFootToSquareMeter_ReturnsValue()
    {
        var conversion = new AreaConversion(AreaUnit.SquareFoot, AreaUnit.SquareMeter);

        conversion.Calculate(1).Should().Be(0.0929030399716017m);
    }

    [Fact]
    public void AreaConversion_FromSquareMeterToSquareFoot_ReturnsValue()
    {
        var conversion = new AreaConversion(AreaUnit.SquareMeter, AreaUnit.SquareFoot);

        conversion.Calculate(1).Should().Be(10.763910419999999540168825336m);
    }

    [Fact]
    public void AreaConversion_WhenMultipliedByQuantityValue_ReturnsValue()
    {
        var conversion = new AreaConversion(AreaUnit.SquareMeter, AreaUnit.SquareFoot);

        var result1 = (QuantityValue)2.5 * conversion.Calculate(1);
        var result2 = conversion.Calculate(1) * (QuantityValue)2.5;

        result1.Should().Be(result2);
        result1.Should().Be(26.909776049999998850422063340m);
    }
}
