using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Types;

namespace Nox.Types.EntityFramework.vNext.TypesConfiguration;


/// <summary>
/// This will move to Nox.Types.EntityFramework, default implementation for Number
/// </summary>
public class NumberDatabaseConfiguration : INoxTypeDatabaseConfiguration
{
    public void ConfigureEntityProperty(EntityTypeBuilder builder, NoxSimpleTypeDefinition property, bool isKey)
    {
        //Todo Default values from static property in the Nox.Type
        var typeOptions = property.NumberTypeOptions ?? new NumberTypeOptions();


        if (isKey)
        {
            builder.HasKey(property.Name);
            // TODO Define Rules and expectations for keys
            // TODO throw new Exception("Use AutoNumber Instead")
        }

        builder
            .Property(property.Name)
            .IsRequired(property.IsRequired)
            .HasConversion(GetConverter(typeOptions));
        // TODO use AutoNumber
        //.If(isKey, p => p.ValueGeneratedOnAdd());
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
        //Opt by Decimal, if precision is higher then 17
        if (typeOptions is { DecimalDigits: > 17 })
        {
            return typeof(NumberToDecimalConverter);
        }

        //Fall back to double, more range less precision
        return typeof(NumberToDoubleConverter);
    }


}