using System;
using System.Collections.Generic;

namespace Nox.Types;

public abstract class MeasurementConversionFactor<TUnitType> where TUnitType : MeasurementUnit
{
    protected abstract Dictionary<(TUnitType, TUnitType), double> DefinedConversionFactors { get; }

    public double Value { get; }

    protected MeasurementConversionFactor(TUnitType sourceUnit, TUnitType targetUnit)
    {
        Value = ResolveConversionFactor(sourceUnit, targetUnit);
    }

    private double ResolveConversionFactor(TUnitType sourceUnit, TUnitType targetUnit)
    {
        var conversion = (sourceUnit, targetUnit);

        if (DefinedConversionFactors.ContainsKey(conversion))
            return DefinedConversionFactors[conversion];


        if (sourceUnit == targetUnit)
            return 1;

        throw new NotImplementedException($"No conversion defined from {sourceUnit?.Name} to {targetUnit?.Name}.");
    }

    public static QuantityValue operator *(QuantityValue value, MeasurementConversionFactor<TUnitType> factor)
        => value * factor.Value;

    public static QuantityValue operator *(MeasurementConversionFactor<TUnitType> factor, QuantityValue value)
        => value * factor;
}