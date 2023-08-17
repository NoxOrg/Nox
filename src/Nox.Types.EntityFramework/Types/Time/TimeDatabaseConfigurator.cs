using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.EntityBuilderAdapter;

namespace Nox.Types.EntityFramework.Types;

/// <summary>
/// The time type database configuration.
/// </summary>
public class TimeDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    /// <inheritdoc/>
    public NoxType ForNoxType => NoxType.Time;

    /// <inheritdoc/>
    public bool IsDefault => true;

    /// <inheritdoc/>
    public void ConfigureEntityProperty(
        NoxSolutionCodeGeneratorState noxSolutionCodeGeneratorState,
        IEntityBuilderAdapter builder,
        NoxSimpleTypeDefinition property,
        Entity entity,
        bool isKey)
    {
        builder
            .Property(property.Name)
            .IsRequired(property.IsRequired)
            .HasConversion<TimeConverter>();
    }

    /// <inheritdoc/>
    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;
}
