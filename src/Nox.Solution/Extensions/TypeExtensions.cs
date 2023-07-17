using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Solution.Extensions;

public static class TypeExtensions
{

    public static bool IsNullable(this Type type)
    {
        if (!type.IsGenericType)
            return false;

        return type.GetGenericTypeDefinition() == typeof(Nullable<>);
    }

    private static readonly HashSet<Type> _simpleTypes = new HashSet<Type>()
    {
        typeof(string),
        typeof(decimal),
        typeof(DateTime),
        typeof(DateTimeOffset),
        typeof(TimeSpan),
        typeof(Guid)
    };

    public static bool IsSimpleType(this Type type)
    {
        return
            type.IsPrimitive ||
            _simpleTypes.Contains(type) ||
            Convert.GetTypeCode(type) != TypeCode.Object;
    }

    public static bool IsNumericType(this Type type)
    {
        return type.IsIntegerType() || type.IsDecimalType();
    }

    private static readonly HashSet<Type> _decimalTypes = new HashSet<Type>
    {
        typeof(double), typeof(decimal), typeof(float)
    };

    public static bool IsDecimalType(this Type type)
    {
        return _decimalTypes.Contains(type);
    }

    private static readonly HashSet<Type> _integerTypes = new HashSet<Type>
    {
        typeof(int), typeof(long), typeof(short), typeof(sbyte),
        typeof(byte), typeof(ulong), typeof(ushort), typeof(uint)
    };

    public static bool IsIntegerType(this Type type)
    {
        return _integerTypes.Contains(type);
    }

    public static bool IsEnumerable(this Type type)
    {
        return type.GetInterfaces().Any(i => i == typeof(IEnumerable));
    }

    public static bool IsDictionary(this Type type)
    {
        return type.GetInterfaces().Any(i => i == typeof(IDictionary)|| i == typeof(IReadOnlyDictionary<,>)) ||
            (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IReadOnlyDictionary<,>));
    }
}