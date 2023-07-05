using System;

namespace Nox.Types;

public enum LengthTypeUnit
{
    Foot = 1,
    Meter = 2,
}

public static class LengthTypeUnitExtensions
{
    public static string ToSymbol(this LengthTypeUnit unit)
    {
        return unit switch
        {
            LengthTypeUnit.Foot => "ft",
            LengthTypeUnit.Meter => "m",
            _ => throw new NotImplementedException($"No symbol defined for unit {unit}.")
        };
    }
}