using System;

namespace Nox.Types;

public enum DistanceTypeUnit
{
    Kilometer = 3,
    Mile = 4,
}

public static class DistanceTypeUnitExtensions
{
    public static string ToSymbol(this DistanceTypeUnit unit)
    {
        return unit switch
        {
            DistanceTypeUnit.Kilometer => "km",
            DistanceTypeUnit.Mile => "mi",
            _ => throw new NotImplementedException($"No symbol defined for unit {unit}.")
        };
    }
}