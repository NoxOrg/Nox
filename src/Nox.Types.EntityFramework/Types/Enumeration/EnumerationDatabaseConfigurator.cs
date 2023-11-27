using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox.Types.EntityFramework.Types;
public class EnumerationDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.Enumeration;

    public virtual bool IsDefault => true;

    public void ConfigureEntityProperty(
        NoxCodeGenConventions noxSolutionCodeGeneratorState,
        NoxSimpleTypeDefinition property,
        Entity entity,
        bool isKey,
        ModelBuilder modelBuilder, EntityTypeBuilder entityTypeBuilder)
    {
        entityTypeBuilder
            .Property(property.Name)
            .IsRequired(property.IsRequired)            
            .HasConversion<EnumerationConverter>();

        entityTypeBuilder
            .HasOne(noxSolutionCodeGeneratorState.GetEntityTypeFullNameForEnumeration(entity.Name, property.Name), null) // No navigation property
            .WithMany()
            .HasForeignKey(property.Name)
            .OnDelete(DeleteBehavior.ClientSetNull);

    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;

    public virtual string? GetColumnType()
    {
        return null;
    }
}
