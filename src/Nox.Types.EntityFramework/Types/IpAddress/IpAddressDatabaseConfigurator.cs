using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.EntityBuilderAdapter;

namespace Nox.Types.EntityFramework.Types;

/// <summary>
/// The ip address database configurator.
/// </summary>
public class IpAddressDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    /// <inheritdoc/>
    public NoxType ForNoxType => NoxType.IpAddress;

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
            .HasMaxLength(63)
            .HasConversion<IpAddressConverter>();
    }

    /// <inheritdoc/>
    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;
}
