using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox.Types.EntityFramework.Types;

public class StreetAddressDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.StreetAddress;
    public bool IsDefault => true;


    public void ConfigureEntityProperty(NoxSolutionCodeGeneratorState noxSolutionCodeGeneratorState, EntityTypeBuilder builder, NoxSimpleTypeDefinition property, Entity entity, bool isKey)
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