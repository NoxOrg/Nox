using Microsoft.EntityFrameworkCore;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.EntityBuilderAdapter;

namespace Nox.Types.EntityFramework.Types;

public class VolumeDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.Volume;

    public virtual bool IsDefault => true;

    public void ConfigureEntityProperty(
        NoxSolutionCodeGeneratorState noxSolutionCodeGeneratorState,
        IEntityBuilderAdapter builder,
        NoxSimpleTypeDefinition property,
        Entity entity,
        bool isKey)
    {
        var typeOptions = property.VolumeTypeOptions ?? new VolumeTypeOptions();

        builder
            .Property(property.Name)
            .IsRequired(property.IsRequired)
            .IfNotNull(GetColumnType(typeOptions), b => b.HasColumnType(GetColumnType(typeOptions)))
            .If(typeOptions.PersistAs == VolumeTypeUnit.CubicMeter,
                propertyToUpdate => propertyToUpdate.HasConversion<VolumeToCubicMetersConverter>())
            .If(typeOptions.PersistAs == VolumeTypeUnit.CubicFoot,
                propertyToUpdate => propertyToUpdate.HasConversion<VolumeToCubicFeetConverter>());
    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;

    public virtual string? GetColumnType(VolumeTypeOptions typeOptions)
    {
        return null;
    }
}
