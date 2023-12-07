using Nox.Types.EntityFramework.Configurations;

namespace Nox.Types.EntityFramework.Extensions;

/// <summary>
/// Provides extension methods for NoxSimpleTypeDefinition for easy conversion to various NoxTypeDatabaseConfiguration instances.
/// </summary>
public static class NoxSimpleTypeDefinitionExtensions
{
    /// <summary>
    /// Converts a NoxSimpleTypeDefinition to an NoxTypeDatabaseConfiguration.
    /// </summary>
    /// <param name="property">The NoxSimpleTypeDefinition to be converted.</param>
    /// <returns>An NoxTypeDatabaseConfiguration instance based on the provided NoxSimpleTypeDefinition.</returns>
    public static NoxTypeDatabaseConfiguration ToNoxTypeDatabaseConfiguration(this NoxSimpleTypeDefinition property)
    {
        return new NoxTypeDatabaseConfiguration(property);
    }

    /// <summary>
    /// Converts a NoxSimpleTypeDefinition to a localized NoxTypeDatabaseConfiguration.
    /// </summary>
    /// <param name="property">The NoxSimpleTypeDefinition to be converted.</param>
    /// <returns>A localized NoxTypeDatabaseConfiguration instance based on the provided NoxSimpleTypeDefinition.</returns>
    public static NoxTypeDatabaseConfiguration ToLocalizedNoxTypeDatabaseConfiguration(this NoxSimpleTypeDefinition property)
    {
        return new NoxTypeDatabaseConfiguration(property, false);
    }
    
    /// <summary>
    /// Converts a NoxSimpleTypeDefinition to an NoxTypeDatabaseConfiguration with additional relation key configuration.
    /// </summary>
    /// <param name="property">The NoxSimpleTypeDefinition to be converted.</param>
    /// <param name="name">The name for the attribute configuration.</param>
    /// <param name="description">The description for the attribute configuration.</param>
    /// <param name="isReadonly">Indicates if the attribute is readonly.</param>
    /// <param name="isRequired">Indicates if the attribute is required.</param>
    /// <returns>An NoxTypeDatabaseConfiguration instance with relation key configuration based on the provided parameters.</returns>
    public static NoxTypeDatabaseConfiguration ToRelationKeyConfiguration(this NoxSimpleTypeDefinition property, string name, string description, bool isReadonly, bool isRequired)
    {
        return new NoxTypeDatabaseConfiguration(property, name, description, isReadonly, isRequired);
    }
}
