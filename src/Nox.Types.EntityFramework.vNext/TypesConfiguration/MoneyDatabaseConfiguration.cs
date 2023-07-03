using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;

namespace Nox.Types.EntityFramework.vNext.TypesConfiguration;

public class MoneyDatabaseConfiguration : INoxTypeDatabaseConfiguration
{

    public void ConfigureEntityProperty(EntityTypeBuilder builder, NoxSimpleTypeDefinition property, bool isKey)
    {
        //Todo Default values from static property in the Nox.Type
        var typeOptions = property.MoneyTypeOptions ?? new MoneyTypeOptions();

        if (isKey)
        {
            throw new NoxEntityFrameworkException("Money type can not be used as a key");
        }

        //TODO Implement OwnsOne  
        //builder
        //    .OwnsOne(property.Name, )
        //    .Property(property.Name)
        //    .IsRequired(property.IsRequired)
        //    .HasConversion(GetConverter(typeOptions));
        //.HasPrecision(typeOptions.DecimalDigits + typeOptions.IntegerDigits, typeOptions.DecimalDigits);
    }

}