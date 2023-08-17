using Nox.Solution;
using Nox.Types.EntityFramework.EntityBuilderAdapter;

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

    void ConfigureEntityProperty(NoxSolutionCodeGeneratorState noxSolutionCodeGeneratorState, IEntityBuilderAdapter builder,
        NoxSimpleTypeDefinition property, Entity entity, bool isKey);

    /// <summary>
    /// Compute the Key Property Name for a Type.
    /// This will be different from property name for Complex Types
    /// </summary>
    string GetKeyPropertyName(NoxSimpleTypeDefinition key);

}