using Nox.Types;

namespace Nox.Solution.Extensions;

/// <summary>
/// Provides extension methods for NoxSimpleTypeDefinition for easy conversion to various AttributeConfiguration instances.
/// </summary>
public static class NoxSimpleTypeDefinitionExtensions
{
    /// <summary>
    /// Converts a NoxSimpleTypeDefinition to an AttributeConfiguration.
    /// </summary>
    /// <param name="property">The NoxSimpleTypeDefinition to be converted.</param>
    /// <returns>An AttributeConfiguration instance based on the provided NoxSimpleTypeDefinition.</returns>
    public static AttributeConfiguration ToAttributeConfiguration(this NoxSimpleTypeDefinition property)
    {
        return new AttributeConfiguration(property);
    }

    /// <summary>
    /// Converts a NoxSimpleTypeDefinition to a localized AttributeConfiguration.
    /// </summary>
    /// <param name="property">The NoxSimpleTypeDefinition to be converted.</param>
    /// <returns>A localized AttributeConfiguration instance based on the provided NoxSimpleTypeDefinition.</returns>
    public static AttributeConfiguration ToLocalizedAttributeConfiguration(this NoxSimpleTypeDefinition property)
    {
        return new AttributeConfiguration(property, false);
    }
    
    /// <summary>
    /// Converts a NoxSimpleTypeDefinition to an AttributeConfiguration with additional relation key configuration.
    /// </summary>
    /// <param name="property">The NoxSimpleTypeDefinition to be converted.</param>
    /// <param name="name">The name for the attribute configuration.</param>
    /// <param name="description">The description for the attribute configuration.</param>
    /// <param name="isReadonly">Indicates if the attribute is readonly.</param>
    /// <param name="isRequired">Indicates if the attribute is required.</param>
    /// <returns>An AttributeConfiguration instance with relation key configuration based on the provided parameters.</returns>
    public static AttributeConfiguration ToRelationKeyConfiguration(this NoxSimpleTypeDefinition property, string name, string description, bool isReadonly, bool isRequired)
    {
        return new AttributeConfiguration(property, name, description, isReadonly, isRequired);
    }
}
