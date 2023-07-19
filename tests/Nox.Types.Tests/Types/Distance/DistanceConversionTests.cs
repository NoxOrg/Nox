using FluentAssertions;
using Nox.Types.Common;

namespace Nox.Types.Tests.Types;

public class DistanceConversionTests
{
    [Fact]
    public void DistanceConversion_FromMileToKilometer_ReturnsValue()
    {
        var conversion = new DistanceConversion(DistanceUnit.Mile, DistanceUnit.Kilometer);

        conversion.Calculate(1).Should().Be(1.60934400315);
    }

    [Fact]
    public void DistanceConversion_FromKilometerToMile_ReturnsValue()
    {
        var conversion = new DistanceConversion(DistanceUnit.Kilometer, DistanceUnit.Mile);

        conversion.Calculate(1).Should().Be(0.62137119102);
    }

    [Fact]
    public void DistanceConversion_WhenMultipliedByQuantityValue_ReturnsValue()
    {
        var conversion = new DistanceConversion(DistanceUnit.Kilometer, DistanceUnit.Mile);

        var result1 = (QuantityValue)2.5 * conversion.Calculate(1);
        var result2 = conversion.Calculate(1) * (QuantityValue)2.5;

        result1.Should().Be(result2);
        result1.Should().Be(1.5534279775500002);
    }
}
