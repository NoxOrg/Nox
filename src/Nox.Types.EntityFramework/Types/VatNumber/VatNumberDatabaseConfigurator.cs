using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox.Types.EntityFramework.Types;

public class VatNumberDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.VatNumber;
    public virtual bool IsDefault => true;

    public void ConfigureEntityProperty(
        NoxCodeGenConventions noxSolutionCodeGeneratorState,
        NoxSimpleTypeDefinition property,
        Entity entity,
        bool isKey,
        ModelBuilder modelBuilder,
        EntityTypeBuilder entityTypeBuilder)
    {
        entityTypeBuilder
            .OwnsOne(typeof(VatNumber), property.Name,
            x =>
            {
                x.Ignore(nameof(VatNumber.Value));
                x.Property(nameof(VatNumber.Number))
                    .IsUnicode(false)
                    .HasMaxLength(64);
                x.Property(nameof(VatNumber.CountryCode))
                    .HasConversion(new EnumToStringConverter<CountryCode>())
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasMaxLength(2);
            });
    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key)
    {
        return key.Name;
    }
}

