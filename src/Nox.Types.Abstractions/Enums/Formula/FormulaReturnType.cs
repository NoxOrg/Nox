using System;

namespace Nox.Types;

/// <summary>
/// Enumeration for possible return types of a formula.
/// </summary>
public enum FormulaReturnType
{
    @string,
    @int,
    @long,
    @double,
    @decimal,
    @bool,
    DateTime,
}

public static class FormulaReturnTypeExtensions
{
    public static Type AsNativeType(this FormulaReturnType type)
        => type switch
        {
            FormulaReturnType.@string => typeof(string),
            FormulaReturnType.@int => typeof(int),
            FormulaReturnType.@long => typeof(long),
            FormulaReturnType.@double => typeof(double),
            FormulaReturnType.@decimal => typeof(decimal),
            FormulaReturnType.@bool => typeof(bool),
            FormulaReturnType.DateTime => typeof(DateTime),
            _ => throw new NotImplementedException(),
        };
}
