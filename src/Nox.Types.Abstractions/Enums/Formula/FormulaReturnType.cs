using System;

namespace Nox.Types;

/// <summary>
/// Enumeration for possible return types of a formula.
/// </summary>
public enum FormulaReturnType
{
    String,
    Int,
    Long,
    Double,
    Bool,
    DateAndTime,
}

public static class FormuaReturnTypeExtensions
{
    public static Type AsNativeType(this FormulaReturnType type)
        => type switch
        {
            FormulaReturnType.String => typeof(string),
            FormulaReturnType.Int => typeof(int),
            FormulaReturnType.Long => typeof(long),
            FormulaReturnType.Double => typeof(double),
            FormulaReturnType.Bool => typeof(bool),
            FormulaReturnType.DateAndTime => typeof(DateTime),
            _ => throw new NotImplementedException(),
        };
}
