using System;

namespace Nox.Solution.Extensions;

public static class EnumExtensions
{
    public static string ToNameList<T>(this T sourceEnum) where T: Enum
    {
        return string.Join(", ", Enum.GetNames(typeof(T)));
    }
}