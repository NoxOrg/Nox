using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox.Types.EntityFramework.Types;

public class StreetAddressDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public void ConfigureEntityProperty(EntityTypeBuilder builder, NoxSimpleTypeDefinition property, bool isKey)
    {
        builder.OwnsOne(typeof(StreetAddress), property.Name,
            x =>
            {
                x.Ignore(nameof(StreetAddress.Value));
                x.Property(nameof(StreetAddress.CountryId))
                    .HasConversion<CountryCode2Converter>();
            });
    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;
}