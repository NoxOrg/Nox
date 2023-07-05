using FluentAssertions;
using Nox.Common;

namespace Nox.Types.Tests.Common;

public class MeasurementConversionFactorTests
{
    [Fact]
    public void MeasurementUnitConverter_GetConversionFactor_FromFootToMeter_ReturnsValue()
    {
        var factor = new Nox.Common.MeasurementConversionFactor(MeasurementTypeUnit.Foot, MeasurementTypeUnit.Meter);

        factor.Value.Should().Be(0.30480000033);
    }

    [Fact]
    public void MeasurementUnitConverter_GetConversionFactor_FromMeterToFoot_ReturnsValue()
    {
        var factor = new Nox.Common.MeasurementConversionFactor(MeasurementTypeUnit.Meter, MeasurementTypeUnit.Foot);

        factor.Value.Should().Be(3.28083989142);
    }

    [Fact]
    public void MeasurementUnitConverter_GetConversionFactor_FromKilometerToMile_ReturnsValue()
    {
        var factor = new Nox.Common.MeasurementConversionFactor(MeasurementTypeUnit.Kilometer, MeasurementTypeUnit.Mile);

        factor.Value.Should().Be(0.62137119102);
    }

    [Fact]
    public void MeasurementUnitConverter_GetConversionFactor_FromMileToKilometer_ReturnsValue()
    {
        var factor = new Nox.Common.MeasurementConversionFactor(MeasurementTypeUnit.Mile, MeasurementTypeUnit.Kilometer);

        factor.Value.Should().Be(1.60934400315);
    }

    [Fact]
    public void MeasurementUnitConverter_GetConversionFactor_FromSquareFootToSquareMeter_ReturnsValue()
    {
        var factor = new Nox.Common.MeasurementConversionFactor(MeasurementTypeUnit.SquareFoot, MeasurementTypeUnit.SquareMeter);

        factor.Value.Should().Be(0.09290304);
    }

    [Fact]
    public void MeasurementUnitConverter_GetConversionFactor_FromSquareMeterToSquareFoot_ReturnsValue()
    {
        var factor = new Nox.Common.MeasurementConversionFactor(MeasurementTypeUnit.SquareMeter, MeasurementTypeUnit.SquareFoot);

        factor.Value.Should().Be(10.76391042);
    }

    [Fact]
    public void MeasurementUnitConverter_GetConversionFactor_WithSameSourceAndTargetUnit_ReturnsValue()
    {
        var factor = new Nox.Common.MeasurementConversionFactor(MeasurementTypeUnit.Foot, MeasurementTypeUnit.Foot);

        factor.Value.Should().Be(1);
    }

    [Fact]
    public void MeasurementUnitConverter_GetConversionFactor_WithUnsupportedConversion_ThrowsException()
    {
        var action = () => new Nox.Common.MeasurementConversionFactor(MeasurementTypeUnit.SquareMeter, MeasurementTypeUnit.Meter);

        action.Should().Throw<NotImplementedException>()
            .WithMessage("No conversion defined from SquareMeter to Meter.");
    }

    [Fact]
    public void MeasurementUnitType_Foot_ReturnsSameValueAsLengthTypeUnit()
    {
        ((int)MeasurementTypeUnit.Foot).Should().Be((int)LengthTypeUnit.Foot);
    }

    [Fact]
    public void MeasurementUnitType_Meter_ReturnsSameValueAsLengthTypeUnit()
    {
        ((int)MeasurementTypeUnit.Meter).Should().Be((int)LengthTypeUnit.Meter);
    }

    [Fact]
    public void MeasurementUnitType_Kilometer_ReturnsSameValueAsDistanceTypeUnit()
    {
        ((int)MeasurementTypeUnit.Kilometer).Should().Be((int)DistanceTypeUnit.Kilometer);
    }

    [Fact]
    public void MeasurementUnitType_Mile_ReturnsSameValueAsDistanceTypeUnit()
    {
        ((int)MeasurementTypeUnit.Mile).Should().Be((int)DistanceTypeUnit.Mile);
    }

    [Fact]
    public void MeasurementUnitType_SquareFoot_ReturnsSameValueAsLengthTypeUnit()
    {
        ((int)MeasurementTypeUnit.SquareFoot).Should().Be((int)AreaTypeUnit.SquareFoot);
    }

    [Fact]
    public void MeasurementUnitType_SquareMeter_ReturnsSameValueAsLengthTypeUnit()
    {
        ((int)MeasurementTypeUnit.SquareMeter).Should().Be((int)AreaTypeUnit.SquareMeter);
    }
}
