using FluentAssertions;
using Nox.Types.Common;

namespace Nox.Types.Tests.Types;

public class DistanceConversionFactorTests
{
    [Fact]
    public void DistanceConversionFactor_FromMileToKilometer_ReturnsValue()
    {
        var factor = new DistanceConversionFactor(DistanceUnit.Mile, DistanceUnit.Kilometer);

        factor.Value.Should().Be(1.60934400315);
    }

    [Fact]
    public void DistanceConversionFactor_FromKilometerToMile_ReturnsValue()
    {
        var factor = new DistanceConversionFactor(DistanceUnit.Kilometer, DistanceUnit.Mile);

        factor.Value.Should().Be(0.62137119102);
    }

    [Fact]
    public void DistanceConversionFactor_WhenMultipliedByQuantityValue_ReturnsValue()
    {
        var factor = new DistanceConversionFactor(DistanceUnit.Kilometer, DistanceUnit.Mile);

        var result1 = (QuantityValue)2.5 * factor;
        var result2 = factor * (QuantityValue)2.5;

        result1.Should().Be(result2);
        result1.Should().Be(1.5534279775500002);
    }
}
