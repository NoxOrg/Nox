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
                    .HasConversion(new EnumToStringConverter<CountryCode>())
                    .IsRequired();
                x.Property(nameof(StreetAddress.AddressLine1))
                    .HasMaxLength(StreetAddress.AddressLine1MaxLength)
                    .IsRequired();
                x.Property(nameof(StreetAddress.PostalCode))
                    .HasMaxLength(StreetAddress.PostalCodeMaxLength)
                    .IsRequired();
                x.Property(nameof(StreetAddress.StreetNumber))
                    .HasMaxLength(StreetAddress.StreetNumberMaxLength);
                x.Property(nameof(StreetAddress.AddressLine2))
                    .HasMaxLength(StreetAddress.AddressLine2MaxLength);
                x.Property(nameof(StreetAddress.Route))
                    .HasMaxLength(StreetAddress.RouteMaxLength);
                x.Property(nameof(StreetAddress.Locality))
                    .HasMaxLength(StreetAddress.LocalityMaxLength);
                x.Property(nameof(StreetAddress.Neighborhood))
                    .HasMaxLength(StreetAddress.NeighborhoodMaxLength);
                x.Property(nameof(StreetAddress.AdministrativeArea1))
                    .HasMaxLength(StreetAddress.AdministrativeArea1MaxLength);
                x.Property(nameof(StreetAddress.AdministrativeArea2))
                    .HasMaxLength(StreetAddress.AdministrativeArea2MaxLength);
            });
    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;
}