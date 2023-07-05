using System;

namespace Nox.Types;

public enum AreaTypeUnit
{
    SquareFoot = 5,
    SquareMeter = 6,
}

public static class AreaTypeUnitExtensions
{
    public static string ToSymbol(this AreaTypeUnit unit)
    {
        return unit switch
        {
            AreaTypeUnit.SquareFoot => "ft²",
            AreaTypeUnit.SquareMeter => "m²",
            _ => throw new NotImplementedException($"No symbol defined for unit {unit}.")
        };
    }
}