using FluentAssertions;
using Nox.Types.Common;

namespace Nox.Types.Tests.Types;

public class AreaConversionFactorTests
{
    [Fact]
    public void AreaConversionFactor_FromSquareFootToSquareMeter_ReturnsValue()
    {
        var factor = new AreaConversionFactor(AreaUnit.SquareFoot, AreaUnit.SquareMeter);

        factor.Value.Should().Be(0.09290304);
    }

    [Fact]
    public void AreaConversionFactor_FromSquareMeterToSquareFoot_ReturnsValue()
    {
        var factor = new AreaConversionFactor(AreaUnit.SquareMeter, AreaUnit.SquareFoot);

        factor.Value.Should().Be(10.76391042);
    }

    [Fact]
    public void AreaConversionFactor_WhenMultipliedByQuantityValue_ReturnsValue()
    {
        var factor = new AreaConversionFactor(AreaUnit.SquareMeter, AreaUnit.SquareFoot);

        var result1 = (QuantityValue)2.5 * factor;
        var result2 = factor * (QuantityValue)2.5;

        result1.Should().Be(result2);
        result1.Should().Be(26.90977605);
    }
}
