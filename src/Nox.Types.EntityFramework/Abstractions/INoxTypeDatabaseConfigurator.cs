using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Configurations;

namespace Nox.Types.EntityFramework.Abstractions;

public interface INoxTypeDatabaseConfigurator
{

    /// <summary>
    /// Configurator for <see cref="NoxType"/>
    /// </summary>
    NoxType ForNoxType { get; }

    /// <summary>
    /// Defines if its default implementation for all database providers
    /// </summary>
    bool IsDefault { get; }

    /// <summary>
    /// Configure database entity property for <see cref="NoxType"/>
    /// </summary>

    void ConfigureEntityProperty(
        NoxCodeGenConventions noxSolutionCodeGeneratorState,
        NoxTypeDatabaseConfiguration property,
        Entity entity,
        bool isKey,
        ModelBuilder modelBuilder,
        EntityTypeBuilder entityTypeBuilder);

    /// <summary>
    /// Compute the Key Property Name for a Type.
    /// This will be different from property name for Complex Types
    /// </summary>
    string GetKeyPropertyName(NoxSimpleTypeDefinition key);

}