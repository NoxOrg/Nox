using System;
using Nox.Types;

namespace Nox.Generator.Infrastructure.Persistence.DatabaseConfiguration;

internal static class ConfigurationDefaults
{
    public static DatabaseAttributeConfig GetDefaultOptions(TextTypeOptions options)
    {
        return new DatabaseAttributeConfig()
        {
            IsSingleProperty = true,
            HasConversionTypeFullName = "Nox.Types.EntityFramework.Types.TextConverter",
            IsUnicode = options.IsUnicode,
            HasMaxLength = options.MaxLength
        };
    }
    public static IDatabaseAttributeConfig GetDefaultOptions(NumberTypeOptions options)
    {
        var converterName = ComputeNumberConverterName(options);
        return new DatabaseAttributeConfig()
        {
            IsSingleProperty = true,
            
            HasConversionTypeFullName = $"Nox.Types.EntityFramework.Types.{converterName}",
            // .HasPrecision(9, 4); // or whatever your schema specifies
        };
    }

    private static string ComputeNumberConverterName(NumberTypeOptions options)
    {
        if (options.DecimalDigits == 0) // integer
        {
            //see https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/integral-numeric-types
            if (options is { MaxValue: <= byte.MaxValue, MinValue: >= byte.MinValue })
            {
                return "NumberToByteConverter";
            }
            if (options is { MaxValue: <= short.MaxValue, MinValue: >= short.MinValue })
            {
                return "NumberToShortConverter";
            }
            if (options is { MaxValue: <= Int32.MaxValue, MinValue: >= Int32.MinValue })
            {
                return "NumberToInt32Converter";
            }
            if (options is { MaxValue: <= Int64.MaxValue, MinValue: >= Int64.MinValue })
            {
                return "NumberToInt64Converter";
            }
        }
        //See https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/floating-point-numeric-types
        //Opt by Decimal, if precision is higher then 17
        if (options is { DecimalDigits: > 17 })
        {
            return "NumberToDecimalConverter";
        }
        
        //Fall back to double, more range less precision
        return "NumberToDoubleConverter";
    }

    // TODO 
    public static bool IsCompoundType(Enum value)
    {
        var fi = value.GetType().GetField(value.ToString());
        var attributes = (CompoundTypeAttribute[])
            fi.GetCustomAttributes(typeof(CompoundTypeAttribute), false);
        return (attributes != null && attributes.Length > 0);
    }

    
}