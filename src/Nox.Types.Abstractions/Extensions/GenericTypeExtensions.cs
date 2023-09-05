using System;

namespace Nox.Extensions;

public static class GenericTypeExtensions
{
    public static T NonNullValue<T>(this T? value) where T : struct
    {
        if (value == null)
        {
            throw new ArgumentNullException();
        }

        return value.Value;
    }

    public static T NonNullValue<T>(this T? value) where T : class
    {
        if (value == null)
        {
            throw new ArgumentNullException();
        }

        return value;
    }
}