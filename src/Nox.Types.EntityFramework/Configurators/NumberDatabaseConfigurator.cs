using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.Types;

namespace Nox.Types.EntityFramework.Configurators;

public class NumberDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public void ConfigureEntityProperty(EntityTypeBuilder builder, NoxSimpleTypeDefinition property, bool isKey)
    {
        //Todo Default values from static property in the Nox.Type
        var typeOptions = property.NumberTypeOptions ?? new NumberTypeOptions();

        if (isKey)
        {
            builder.HasKey(property.Name);
        }

        builder
            .Property(property.Name)
            .IsRequired(property.IsRequired)
            .HasConversion(GetConverter(typeOptions));
    }

    public Type GetConverter(NumberTypeOptions typeOptions)
    {
        if (typeOptions.DecimalDigits == 0) // integer
        {
            //see https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/integral-numeric-types
            if (typeOptions is { MaxValue: <= byte.MaxValue, MinValue: >= byte.MinValue })
            {
                return typeof(NumberToByteConverter);
            }

            if (typeOptions is { MaxValue: <= short.MaxValue, MinValue: >= short.MinValue })
            {
                return typeof(NumberToShortConverter);
            }

            if (typeOptions is { MaxValue: <= int.MaxValue, MinValue: >= int.MinValue })
            {
                return typeof(NumberToInt32Converter);
            }

            if (typeOptions is { MaxValue: <= long.MaxValue, MinValue: >= long.MinValue })
            {
                return typeof(NumberToInt64Converter);
            }
        }

        //See https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/floating-point-numeric-types
        
        //Fall back to decimal
        return typeof(NumberToDecimalConverter);
    }
}