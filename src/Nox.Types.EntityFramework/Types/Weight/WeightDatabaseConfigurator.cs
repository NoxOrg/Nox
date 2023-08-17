using Microsoft.EntityFrameworkCore;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.EntityBuilderAdapter;

namespace Nox.Types.EntityFramework.Types;

public class WeightDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.Weight;

    public virtual bool IsDefault => true;

    public void ConfigureEntityProperty(
        NoxSolutionCodeGeneratorState noxSolutionCodeGeneratorState,
        IEntityBuilderAdapter builder,
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
