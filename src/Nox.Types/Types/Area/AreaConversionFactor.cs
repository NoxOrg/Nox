using Nox.Types.Common;
using System.Collections.Generic;

namespace Nox.Types;

public class AreaConversionFactor : MeasurementConversionFactor<AreaUnit>
{
    private static readonly Dictionary<(AreaUnit, AreaUnit), double> _definedAreaConversionFactors = new()
    {
        { (AreaUnit.SquareFoot,  AreaUnit.SquareMeter), 0.09290304 },
        { (AreaUnit.SquareMeter,  AreaUnit.SquareFoot), 10.76391042 },
    };

    protected override Dictionary<(AreaUnit, AreaUnit), double> DefinedConversionFactors => _definedAreaConversionFactors;

    public AreaConversionFactor(AreaUnit sourceUnit, AreaUnit targetUnit)
        : base(sourceUnit, targetUnit)
    {
    }
}
