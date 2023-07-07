using System;

namespace Nox.Types;

public enum TemperatureTypeUnit
{
    Celsius,
    Fahrenheit,
}

public static class TemperatureTypeUnitExtensions
{
    public static string ToSymbol(this TemperatureTypeUnit unit)
    {
        return unit switch
        {
            TemperatureTypeUnit.Celsius => "C",
            TemperatureTypeUnit.Fahrenheit => "F",
            _ => throw new NotImplementedException($"No symbol defined for unit {unit}.")
        };
    }
}