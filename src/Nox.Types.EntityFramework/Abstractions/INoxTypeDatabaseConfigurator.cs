using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Generator.Common;
using Nox.Solution;

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
    /// Configure ModelBuilder Property for a Type
    /// </summary>

    void ConfigureEntityProperty(NoxSolutionCodeGeneratorState noxSolutionCodeGeneratorState, EntityTypeBuilder builder,
        NoxSimpleTypeDefinition property, Entity entity, bool isKey);

    /// <summary>
    /// Compute the Key Property Name for a Type.
    /// This will be different from property name for Complex Types
    /// </summary>
    string GetKeyPropertyName(NoxSimpleTypeDefinition key);

}