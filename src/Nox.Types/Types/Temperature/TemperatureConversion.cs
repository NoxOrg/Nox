using Nox.Types.Common;
using System;
using System.Collections.Generic;

namespace Nox.Types;

public class TemperatureConversion : MeasurementConversion<TemperatureUnit>
{
    private static readonly Dictionary<(TemperatureUnit, TemperatureUnit), Func<QuantityValue, QuantityValue>> _definedTempeatureConversionFormulas = new()
    {
        { (TemperatureUnit.Celsius,  TemperatureUnit.Fahrenheit), (val) =>  val * 9m / 5m + 32m },
        { (TemperatureUnit.Fahrenheit,  TemperatureUnit.Celsius), (val) =>  (val - 32m) * 5m / 9m },
    };

    protected override Dictionary<(TemperatureUnit, TemperatureUnit), Func<QuantityValue, QuantityValue>> DefinedConversionFormulas => _definedTempeatureConversionFormulas;

    public TemperatureConversion(TemperatureUnit sourceUnit, TemperatureUnit targetUnit)
        : base(sourceUnit, targetUnit)
    {
    }
}