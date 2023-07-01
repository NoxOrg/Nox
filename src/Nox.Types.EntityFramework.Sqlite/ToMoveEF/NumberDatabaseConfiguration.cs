using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Types;

namespace Nox.Types.EntityFramework.Sqlite.ToMoveEF;


/// <summary>
/// This will move to Nox.Types.EntityFramework, default implementation for Number
/// </summary>
public class NumberDatabaseConfiguration : INoxTypeDatabaseConfiguration
{
    public void ConfigureEntityProperty<TEntity, TProperty>(NoxSolution noxSolution,
        string propertyName,
        EntityTypeBuilder<TEntity> builder,
        Expression<Func<TEntity, TProperty>> property) where TEntity : class where TProperty : class
    {
        // TODO get from Nox Solutin
        // TODO get from Nox Solutin using propertyname
        var typeOptions = new NumberTypeOptions();

        var noxPropertyBuilder = builder.Property(property) as PropertyBuilder<Number>;

        noxPropertyBuilder!
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
        //Opt by Decimal, if precision is higher then 17
        if (typeOptions is { DecimalDigits: > 17 })
        {
            return typeof(NumberToDecimalConverter);
        }

        //Fall back to double, more range less precision
        return typeof(NumberToDoubleConverter);
    }
}