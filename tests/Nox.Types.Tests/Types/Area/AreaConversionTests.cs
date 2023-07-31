using FluentAssertions;
using Nox.Types.Common;

namespace Nox.Types.Tests.Types;

public class AreaConversionTests
{
    [Fact]
    public void AreaConversion_FromSquareFootToSquareMeter_ReturnsValue()
    {
        var conversion = new AreaConversion(AreaUnit.SquareFoot, AreaUnit.SquareMeter);

        conversion.Calculate(1).Should().Be(0.09290304m);
    }

    [Fact]
    public void AreaConversion_FromSquareMeterToSquareFoot_ReturnsValue()
    {
        var conversion = new AreaConversion(AreaUnit.SquareMeter, AreaUnit.SquareFoot);

        conversion.Calculate(1).Should().Be(10.763910416709722308333505556m);
    }

    [Fact]
    public void AreaConversion_WhenMultipliedByQuantityValue_ReturnsValue()
    {
        var conversion = new AreaConversion(AreaUnit.SquareMeter, AreaUnit.SquareFoot);

        var result1 = (QuantityValue)2.5 * conversion.Calculate(1);
        var result2 = conversion.Calculate(1) * (QuantityValue)2.5;

        result1.Should().Be(result2);
        result1.Should().Be(26.909776041774305770833763890m);
    }
}
