using Nox.Yaml.Tests.TestDesigns.Nox.Types.Interfaces;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Types.TypeOptions;

public class NumberTypeOptions : INoxTypeOptionsWithDynamicType
{
    // Default Create Options
    public static readonly decimal DefaultMinValue = -999999999;
    public static readonly decimal DefaultMaxValue = +999999999;

    // Validation Properties
    public decimal MinValue { get; set; } = DefaultMinValue;
    public decimal MaxValue { get; set; } = DefaultMaxValue;
    // Database Options
    public uint DecimalDigits { get; set; } = 0;


    public Type GetUnderlyingType()
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