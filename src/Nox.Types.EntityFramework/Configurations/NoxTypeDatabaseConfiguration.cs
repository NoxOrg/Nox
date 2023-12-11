using Nox.Yaml.Attributes;

namespace Nox.Types.EntityFramework.Configurations;

/// <summary>
/// Represents the configuration for an attribute, encapsulating various settings and options.
/// </summary>
public class NoxTypeDatabaseConfiguration
{
    /// <summary>
    /// Initializes a new instance of the NoxTypeDatabaseConfiguration class using a NoxSimpleTypeDefinition.
    /// </summary>
    /// <param name="property">The NoxSimpleTypeDefinition to configure the attribute.</param>
    public NoxTypeDatabaseConfiguration(NoxSimpleTypeDefinition property)
        : this(property, property.Name, property.Description, property.IsReadonly, property.IsRequired)
    {
    }

    /// <summary>
    /// Initializes a new instance of the NoxTypeDatabaseConfiguration class with a required status specification.
    /// </summary>
    /// <param name="property">The NoxSimpleTypeDefinition to configure the attribute.</param>
    /// <param name="isRequired">Indicates if the attribute is required.</param>
    public NoxTypeDatabaseConfiguration(NoxSimpleTypeDefinition property, bool isRequired)
        : this(property, property.Name, property.Description, property.IsReadonly, isRequired)
    {
    }

    /// <summary>
    /// Initializes a new instance of the NoxTypeDatabaseConfiguration class with detailed parameters.
    /// </summary>
    /// <param name="property">The NoxSimpleTypeDefinition to configure the attribute.</param>
    /// <param name="name">The name of the attribute.</param>
    /// <param name="description">The description of the attribute.</param>
    /// <param name="isReadonly">Indicates if the attribute is readonly.</param>
    /// <param name="isRequired">Indicates if the attribute is required.</param>
    public NoxTypeDatabaseConfiguration(
        NoxSimpleTypeDefinition property,
        string name,
        string? description,
        bool isReadonly,
        bool isRequired)
    {
        Name = name;
        Description = description;
        IsRequired = isRequired;
        IsReadonly = isReadonly;
        IsLocalized = property.IsLocalized;
        Type = property.Type;
        SetTypeOptions(property);
    }


    public string Name { get; }
    public string? Description { get; }
    public bool IsReadonly { get; set; }
    public bool IsLocalized { get; }
    public bool IsRequired { get; }

    public NoxType Type { get; }

    private INoxTypeOptions? _noxTypeOptions;

    private void SetTypeOptions(NoxSimpleTypeDefinition simpleTypeDefinition)
    {
        
        var propertyInfo = Array.Find(simpleTypeDefinition.GetType().GetProperties(), 
            p => Array.Exists((IfEqualsAttribute[])p.GetCustomAttributes(typeof(IfEqualsAttribute), true), a => 
                a.Property == nameof(simpleTypeDefinition.Type) && a.Value.Equals(simpleTypeDefinition.Type)));
        
        _noxTypeOptions = (INoxTypeOptions?)propertyInfo?.GetValue(simpleTypeDefinition);
    }
    
    public T GetTypeOptions<T>() where T : INoxTypeOptions
    {
        if (_noxTypeOptions is null)
        {
            return (T)Activator.CreateInstance(typeof(T))!;
        }

        return (T)_noxTypeOptions;
    }
}