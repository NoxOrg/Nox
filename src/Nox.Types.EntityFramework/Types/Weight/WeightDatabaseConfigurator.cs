using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Nox.Enums;
using Nox.Solution;
using Nox.TypeOptions;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox.Types.EntityFramework.Types;

public class WeightDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.Weight;

    public virtual bool IsDefault => true;

    public void ConfigureEntityProperty(
        NoxSolutionCodeGeneratorState noxSolutionCodeGeneratorState,
        EntityTypeBuilder builder,
        NoxSimpleTypeDefinition property,
        Entity entity,
        bool isKey)
    {
        var typeOptions = property.WeightTypeOptions ?? new WeightTypeOptions();

        builder
            .Property(property.Name)
            .IsRequired(property.IsRequired)
            .IfNotNull(GetColumnType(typeOptions), b => b.HasColumnType(GetColumnType(typeOptions)))
            .If(typeOptions.PersistAs == WeightTypeUnit.Pound,
                propertyToUpdate => propertyToUpdate.HasConversion<WeightToPoundsConverter>())
            .If(typeOptions.PersistAs == WeightTypeUnit.Kilogram,
                propertyToUpdate => propertyToUpdate.HasConversion<WeightToKilogramsConverter>());
    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;

    public virtual string? GetColumnType(WeightTypeOptions typeOptions)
    {
        return null;
    }
}
