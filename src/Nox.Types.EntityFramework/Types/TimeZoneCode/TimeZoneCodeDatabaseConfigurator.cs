using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox.Types.EntityFramework.Types;

/// <summary>
/// The time zone code type database configuration.
/// </summary>
public class TimeZoneCodeDatabaseConfigurator : INoxTypeDatabaseConfigurator
{
    /// <inheritdoc/>
    public NoxType ForNoxType => NoxType.TimeZoneCode;

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
            .IsUnicode(false)
            .HasMaxLength(5)
            .HasConversion<TimeZoneCodeConverter>();
    }

    /// <inheritdoc/>
    public string GetKeyPropertyName(NoxSimpleTypeDefinition key) => key.Name;
}
