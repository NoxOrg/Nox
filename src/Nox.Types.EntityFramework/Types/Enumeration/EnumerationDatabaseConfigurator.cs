using Microsoft.EntityFrameworkCore;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.EntityBuilderAdapter;

namespace Nox.Types.EntityFramework.Types;
public class EnumerationDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.Enumeration;

    public virtual bool IsDefault => true;

    public void ConfigureEntityProperty(
        NoxCodeGenConventions noxSolutionCodeGeneratorState,
        IEntityBuilder builder,
        NoxSimpleTypeDefinition property,
        Entity entity,
        bool isKey)
    {
        builder
            .Property(property.Name)
            .IsRequired(property.IsRequired)            
            .HasConversion<EnumerationConverter>();

        builder
            .HasOne(noxSolutionCodeGeneratorState.GetEntityTypeFullNameForEnumType(entity.Name, property.Name), null) // No navigation property
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
