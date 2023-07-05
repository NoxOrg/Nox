using System.Collections.Generic;

namespace Nox.Types;

public class VolumeConversionFactor : MeasurementConversionFactor<VolumeUnit>
{
    private static readonly Dictionary<(VolumeUnit, VolumeUnit), double> _definedVolumeConversionFactors = new()
    {
        { (VolumeUnit.CubicFoot,  VolumeUnit.CubicMeter), 0.0283168466 },
        { (VolumeUnit.CubicMeter,  VolumeUnit.CubicFoot), 35.3146667 },
    };

    protected override Dictionary<(VolumeUnit, VolumeUnit), double> DefinedConversionFactors => _definedVolumeConversionFactors;

    public VolumeConversionFactor(VolumeUnit sourceUnit, VolumeUnit targetUnit)
        : base(sourceUnit, targetUnit)
    {
    }
}