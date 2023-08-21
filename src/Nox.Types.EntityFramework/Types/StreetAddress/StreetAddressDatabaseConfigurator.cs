using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.EntityBuilderAdapter;

namespace Nox.Types.EntityFramework.Types;

public class StreetAddressDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.StreetAddress;
    public bool IsDefault => true;


    public void ConfigureEntityProperty(
        NoxSolutionCodeGeneratorState noxSolutionCodeGeneratorState,
        IEntityBuilder builder,
        NoxSimpleTypeDefinition property,
        Entity entity,
        bool isKey)
    {
        builder.OwnsOne(typeof(StreetAddress), property.Name,
            x =>
            {
                x.Ignore(nameof(StreetAddress.Value));
                x.Property(nameof(StreetAddress.CountryId))
                    .HasConversion( new EnumToStringConverter<CountryCode>() );
            });
    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;
}