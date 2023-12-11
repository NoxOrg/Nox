using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.Configurations;

namespace Nox.Types.EntityFramework.Types;
public class PhoneNumberDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.PhoneNumber;

    public virtual bool IsDefault => true;

    public void ConfigureEntityProperty(
        NoxCodeGenConventions noxSolutionCodeGeneratorState,
        NoxTypeDatabaseConfiguration property,
        Entity entity,
        bool isKey,
        ModelBuilder modelBuilder,
        EntityTypeBuilder entityTypeBuilder)
    {
        entityTypeBuilder
            .Property(property.Name)
            .IsRequired(property.IsRequired)
            .HasMaxLength(PhoneNumber.MaxPhoneNumberLength)
            .HasConversion<PhoneNumberConverter>();
    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;
}

