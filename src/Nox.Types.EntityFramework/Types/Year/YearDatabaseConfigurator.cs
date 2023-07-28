using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox.Types.EntityFramework.Types;

public class YearDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    public NoxType ForNoxType => NoxType.Year;
    public virtual bool IsDefault => true;

    public void ConfigureEntityProperty(
        NoxSolutionCodeGeneratorState noxSolutionCodeGeneratorState,
        EntityTypeBuilder builder,
        NoxSimpleTypeDefinition property,
        Entity entity,
        bool isKey)
    {
        // TODO: Default values from static property in the Nox.Type
        var typeOptions = property.YearTypeOptions ?? new YearTypeOptions();

        builder
            .Property(property.Name)
            .IsRequired(property.IsRequired)
            .HasMaxLength((int)typeOptions.MaxValue)
            .IfNotNull(GetColumnType(typeOptions), b => b.HasColumnType(GetColumnType(typeOptions)))
            .HasConversion<YearToUShortConverter>();
    }

    public virtual string? GetColumnType(YearTypeOptions typeOptions)
    {
        return null;
    }

    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;
}