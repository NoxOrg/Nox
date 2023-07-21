using System;
using System.Collections.Generic;

namespace Nox.Types.Common;

public abstract class MeasurementConversion<TUnitType> where TUnitType : MeasurementUnit
{
    protected abstract Dictionary<(TUnitType, TUnitType), Func<QuantityValue, QuantityValue>> DefinedConversionFormulas { get; }

    public Func<QuantityValue, QuantityValue> Calculate { get; }

    protected MeasurementConversion(TUnitType sourceUnit, TUnitType targetUnit)
    {
        Calculate = ResolveConversion(sourceUnit, targetUnit);
    }

    private Func<QuantityValue, QuantityValue> ResolveConversion(TUnitType sourceUnit, TUnitType targetUnit)
    {
        var conversion = (sourceUnit, targetUnit);

        if (DefinedConversionFormulas.ContainsKey(conversion))
            return DefinedConversionFormulas[conversion];


        if (sourceUnit == targetUnit)
            return (val) => val;

        throw new NotImplementedException($"No conversion defined from {sourceUnit?.Name} to {targetUnit?.Name}.");
    }
}