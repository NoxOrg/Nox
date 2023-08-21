using Microsoft.EntityFrameworkCore;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.EntityBuilderAdapter;

namespace Nox.Types.EntityFramework.Types;

public class AreaDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.Area;
    public virtual bool IsDefault => true;

    public void ConfigureEntityProperty(
        NoxSolutionCodeGeneratorState noxSolutionCodeGeneratorState,
        IEntityBuilder builder,
        NoxSimpleTypeDefinition property,
        Entity entity,
        bool isKey)
    {
        var typeOptions = property.AreaTypeOptions ?? new AreaTypeOptions();

        builder
            .Property(property.Name)
            .IsRequired(property.IsRequired)
            .IfNotNull(GetColumnType(typeOptions), b => b.HasColumnType(GetColumnType(typeOptions)))
            .If(typeOptions.PersistAs == AreaTypeUnit.SquareFoot,
                propertyToUpdate => propertyToUpdate.HasConversion<AreaToSquareFootConverter>())
            .If(typeOptions.PersistAs == AreaTypeUnit.SquareMeter,
                propertyToUpdate => propertyToUpdate.HasConversion<AreaToSquareMeterConverter>());
    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;

    public virtual string? GetColumnType(AreaTypeOptions typeOptions)
    {
        return null;
    }
}