using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox.Types.EntityFramework.Types;

public class LengthDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.Length;
    public bool IsDefault => true;

    public void ConfigureEntityProperty(
        NoxSolutionCodeGeneratorState noxSolutionCodeGeneratorState,
        EntityTypeBuilder builder,
        NoxSimpleTypeDefinition property,
        Entity entity,
        bool isKey)
    {
        var typeOptions = property.LengthTypeOptions ?? new LengthTypeOptions();

        builder
            .Property(property.Name)
            .IsRequired(property.IsRequired)
            .If(typeOptions.PersistAs == LengthTypeUnit.Foot,
                propertyToUpdate => propertyToUpdate.HasConversion<LengthToFootConverter>())
            .If(typeOptions.PersistAs == LengthTypeUnit.Meter,
                propertyToUpdate => propertyToUpdate.HasConversion<LengthToMeterConverter>());
    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;
}
