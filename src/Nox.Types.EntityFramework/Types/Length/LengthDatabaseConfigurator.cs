using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox.Types.EntityFramework.Types;

public class LengthDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.Length;
    public virtual bool IsDefault => true;

    public void ConfigureEntityProperty(
        NoxCodeGenConventions noxSolutionCodeGeneratorState,
        NoxSimpleTypeDefinition property,
        Entity entity,
        bool isKey,
        ModelBuilder modelBuilder, 
        EntityTypeBuilder entityTypeBuilder)
    {
        var typeOptions = property.LengthTypeOptions ?? new LengthTypeOptions();

        entityTypeBuilder
            .Property(property.Name)
            .IsRequired(property.IsRequired)
            .IfNotNull(GetColumnType(typeOptions), b => b.HasColumnType(GetColumnType(typeOptions)))
            .If(typeOptions.PersistAs == LengthTypeUnit.Foot,
                propertyToUpdate => propertyToUpdate.HasConversion<LengthToFootConverter>())
            .If(typeOptions.PersistAs == LengthTypeUnit.Meter,
                propertyToUpdate => propertyToUpdate.HasConversion<LengthToMeterConverter>());
    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;

    public virtual string? GetColumnType(LengthTypeOptions typeOptions)
    {
        return null;
    }
}
