using System;
using System.Collections.Generic;
using Nox.Types.Common;

namespace Nox.Types;

public class VolumeConversion : MeasurementConversion<VolumeUnit>
{
    private static readonly Dictionary<(VolumeUnit, VolumeUnit), Func<QuantityValue, QuantityValue>> DefinedVolumeConversionFormulas = new()
    {
        { (VolumeUnit.CubicFoot,  VolumeUnit.CubicMeter), (val) => val * 0.0283168466 },
        { (VolumeUnit.CubicMeter,  VolumeUnit.CubicFoot), (val) => val * 35.3146667 },
    };

    protected override Dictionary<(VolumeUnit, VolumeUnit), Func<QuantityValue, QuantityValue>> DefinedConversionFormulas => DefinedVolumeConversionFormulas;

    public VolumeConversion(VolumeUnit sourceUnit, VolumeUnit targetUnit)
        : base(sourceUnit, targetUnit)
    {
    }
}