using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nox.Solution;
using Nox.Types.Extensions;
using Nox.Types.EntityFramework.Abstractions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Types.EntityFramework.Configurations;

namespace Nox.Types.EntityFramework.Types;

public class StreetAddressDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    private static readonly NoxType StreetAddressNoxType = NoxType.StreetAddress;
    private static readonly Dictionary<string, CompoundComponent> ComponentsByPropertyName = GetComponentsByPropertyName();

    public NoxType ForNoxType => StreetAddressNoxType;
    public bool IsDefault => true;

    public void ConfigureEntityProperty(
        NoxCodeGenConventions noxSolutionCodeGeneratorState,
        NoxTypeDatabaseConfiguration property,
        Entity entity,
        bool isKey,
        ModelBuilder modelBuilder,
        EntityTypeBuilder entityTypeBuilder)
    {
        entityTypeBuilder.OwnsOne(typeof(StreetAddress), property.Name,
            x =>
            {
                x.Ignore(nameof(StreetAddress.Value));

                x.Property(nameof(StreetAddress.CountryId))
                    .HasConversion(new EnumToStringConverter<CountryCode>())
                    .HasMaxLength(2)
                    .IsRequired(GetRequiredFlag(nameof(StreetAddress.CountryId)));

                x.Property(nameof(StreetAddress.AddressLine1))
                    .HasMaxLength(StreetAddress.AddressLine1MaxLength)
                    .IsRequired(GetRequiredFlag(nameof(StreetAddress.AddressLine1)));

                x.Property(nameof(StreetAddress.PostalCode))
                    .HasMaxLength(StreetAddress.PostalCodeMaxLength)
                    .IsRequired(GetRequiredFlag(nameof(StreetAddress.PostalCode)));

                x.Property(nameof(StreetAddress.StreetNumber))
                    .HasMaxLength(StreetAddress.StreetNumberMaxLength)
                    .IsRequired(GetRequiredFlag(nameof(StreetAddress.StreetNumber)));

                x.Property(nameof(StreetAddress.AddressLine2))
                    .HasMaxLength(StreetAddress.AddressLine2MaxLength)
                    .IsRequired(GetRequiredFlag(nameof(StreetAddress.AddressLine2)));

                x.Property(nameof(StreetAddress.Route))
                    .HasMaxLength(StreetAddress.RouteMaxLength)
                    .IsRequired(GetRequiredFlag(nameof(StreetAddress.Route)));

                x.Property(nameof(StreetAddress.Locality))
                    .HasMaxLength(StreetAddress.LocalityMaxLength)
                    .IsRequired(GetRequiredFlag(nameof(StreetAddress.Locality)));

                x.Property(nameof(StreetAddress.Neighborhood))
                    .HasMaxLength(StreetAddress.NeighborhoodMaxLength)
                    .IsRequired(GetRequiredFlag(nameof(StreetAddress.Neighborhood)));

                x.Property(nameof(StreetAddress.AdministrativeArea1))
                    .HasMaxLength(StreetAddress.AdministrativeArea1MaxLength)
                    .IsRequired(GetRequiredFlag(nameof(StreetAddress.AdministrativeArea1)));

                x.Property(nameof(StreetAddress.AdministrativeArea2))
                    .HasMaxLength(StreetAddress.AdministrativeArea2MaxLength)
                    .IsRequired(GetRequiredFlag(nameof(StreetAddress.AdministrativeArea2)));
            });
    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;

    private static bool GetRequiredFlag(string propertyName)
    {
        ComponentsByPropertyName.TryGetValue(propertyName, out var component);
        return component?.IsRequired ?? true;
    }

    private static Dictionary<string, CompoundComponent> GetComponentsByPropertyName()
    {
        return StreetAddressNoxType
            .ToMemberInfo()
            .GetCustomAttributes<CompoundComponent>()
            .ToDictionary(x => x.Name, x => x);
    }
}