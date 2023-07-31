using Nox.Types.Common;
using System;
using System.Collections.Generic;

namespace Nox.Types;

internal class AreaConversion : MeasurementConversion<AreaUnit>
{
    private static readonly Dictionary<(AreaUnit, AreaUnit), Func<QuantityValue, QuantityValue>> _definedAreaConversionFormulas = new()
    {
        { (AreaUnit.SquareFoot,  AreaUnit.SquareMeter), (val) => val * 0.09290304m },
        { (AreaUnit.SquareMeter,  AreaUnit.SquareFoot), (val) => val / 0.09290304m },
    };

    protected override Dictionary<(AreaUnit, AreaUnit), Func<QuantityValue, QuantityValue>> DefinedConversionFormulas => _definedAreaConversionFormulas;

    public AreaConversion(AreaUnit sourceUnit, AreaUnit targetUnit)
        : base(sourceUnit, targetUnit)
    {
    }
}
