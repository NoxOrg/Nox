using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

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
        NoxCodeGenConventions noxSolutionCodeGeneratorState,
        NoxSimpleTypeDefinition property,
        Entity entity,
        bool isKey,
        ModelBuilder modelBuilder,
        EntityTypeBuilder entityTypeBuilder)
    {
        entityTypeBuilder
            .Property(property.Name)
            .IsRequired(property.IsRequired)
            .HasMaxLength(63)
            .HasConversion<IpAddressConverter>();
    }

    /// <inheritdoc/>
    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;
}
