using Nox.Types.Common;
using System;
using System.Collections.Generic;

namespace Nox.Types;

public class AreaConversion : MeasurementConversion<AreaUnit>
{
    private static readonly Dictionary<(AreaUnit, AreaUnit), Func<QuantityValue, QuantityValue>> _definedAreaConversionFormulas = new()
    {
        { (AreaUnit.SquareFoot,  AreaUnit.SquareMeter), (val) => val * 0.0929030399716017M },
        { (AreaUnit.SquareMeter,  AreaUnit.SquareFoot), (val) => val * 10.76391042M },
    };

    protected override Dictionary<(AreaUnit, AreaUnit), Func<QuantityValue, QuantityValue>> DefinedConversionFormulas => _definedAreaConversionFormulas;

    public AreaConversion(AreaUnit sourceUnit, AreaUnit targetUnit)
        : base(sourceUnit, targetUnit)
    {
    }
}
