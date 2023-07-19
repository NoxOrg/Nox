using FluentAssertions;
using Nox.Types.Common;

namespace Nox.Types.Tests.Types;

public class VolumeConversionTests
{
    [Fact]
    public void VolumeConversion_FromCubicFootToCubicMeter_ReturnsValue()
    {
        var conversion = new VolumeConversion(VolumeUnit.CubicFoot, VolumeUnit.CubicMeter);

        conversion.Calculate.Should().Be(0.0283168466);
    }
}
