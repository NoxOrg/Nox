using System;
using System.Collections.Generic;
using Nox.Types.Common;

namespace Nox.Types;

public class VolumeConversion : MeasurementConversion<VolumeUnit>
{
    private static readonly Dictionary<(VolumeUnit, VolumeUnit), Func<QuantityValue, QuantityValue>> _definedVolumeConversionFormulas = new()
    {
        { (VolumeUnit.CubicFoot,  VolumeUnit.CubicMeter), (val) => val * 0.0283168466 },
        { (VolumeUnit.CubicMeter,  VolumeUnit.CubicFoot), (val) => val * 35.3146667 },
    };

    protected override Dictionary<(VolumeUnit, VolumeUnit), Func<QuantityValue, QuantityValue>> DefinedConversionFormulas => _definedVolumeConversionFormulas;

    public VolumeConversion(VolumeUnit sourceUnit, VolumeUnit targetUnit)
        : base(sourceUnit, targetUnit)
    {
    }
}