using System;

namespace Nox.Types;

public class NumberTypeOptions : IHaveUnderLineTypeOptions
{
    public static readonly decimal DefaultMinValue = -999999999;
    public static readonly decimal DefaultMaxValue = +999999999;
    public decimal MinValue { get; set; } = DefaultMinValue;
    public decimal MaxValue { get; set; } = DefaultMaxValue;
    public uint DecimalDigits { get; set; } = 0;


    public Type GetUnderlineType()
    {
        if (DecimalDigits == 0) // integer
        {
            //see https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/integral-numeric-types
            if (MaxValue <= byte.MaxValue && MinValue >= byte.MinValue)
            {
                return typeof(byte);
            }

            if (MaxValue <= short.MaxValue && MinValue >= short.MinValue)
            {
                return typeof(short);
            }

            if (MaxValue <= int.MaxValue && MinValue >= int.MinValue)
            {
                return typeof(int);
            }

            if (MaxValue <= long.MaxValue && MinValue >= long.MinValue)
            {
                return typeof(long);
            }
        }

        //See https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/floating-point-numeric-types

        //Fall back to decimal
        return typeof(decimal);
    }
}