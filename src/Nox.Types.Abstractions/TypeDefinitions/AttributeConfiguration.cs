namespace Nox.Types;

/// <summary>
/// Represents the configuration for an attribute, encapsulating various settings and options.
/// </summary>
public class AttributeConfiguration
{
    /// <summary>
    /// Initializes a new instance of the AttributeConfiguration class using a NoxSimpleTypeDefinition.
    /// </summary>
    /// <param name="property">The NoxSimpleTypeDefinition to configure the attribute.</param>
    public AttributeConfiguration(NoxSimpleTypeDefinition property)
        : this(property, property.Name, property.Description, property.IsReadonly, property.IsRequired)
    {
    }

    /// <summary>
    /// Initializes a new instance of the AttributeConfiguration class with a required status specification.
    /// </summary>
    /// <param name="property">The NoxSimpleTypeDefinition to configure the attribute.</param>
    /// <param name="isRequired">Indicates if the attribute is required.</param>
    public AttributeConfiguration(NoxSimpleTypeDefinition property, bool isRequired)
        : this(property, property.Name, property.Description, property.IsReadonly, isRequired)
    {
    }

    /// <summary>
    /// Initializes a new instance of the AttributeConfiguration class with detailed parameters.
    /// </summary>
    /// <param name="property">The NoxSimpleTypeDefinition to configure the attribute.</param>
    /// <param name="name">The name of the attribute.</param>
    /// <param name="description">The description of the attribute.</param>
    /// <param name="isReadonly">Indicates if the attribute is readonly.</param>
    /// <param name="isRequired">Indicates if the attribute is required.</param>
    public AttributeConfiguration(
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
        AreaTypeOptions = property.AreaTypeOptions;
        AutoNumberTypeOptions = property.AutoNumberTypeOptions;
        LengthTypeOptions = property.LengthTypeOptions;
        MarkdownTypeOptions = property.MarkdownTypeOptions;
        MoneyTypeOptions = property.MoneyTypeOptions;
        NuidTypeOptions = property.NuidTypeOptions;
        NumberTypeOptions = property.NumberTypeOptions;
        PercentageTypeOptions = property.PercentageTypeOptions;
        ReferenceNumberTypeOptions = property.ReferenceNumberTypeOptions;
        TemperatureTypeOptions = property.TemperatureTypeOptions;
        TextTypeOptions = property.TextTypeOptions;
        UserTypeOptions = property.UserTypeOptions;
        VolumeTypeOptions = property.VolumeTypeOptions;
        WeightTypeOptions = property.WeightTypeOptions;
        DistanceTypeOptions = property.DistanceTypeOptions;
        FormulaTypeOptions = property.FormulaTypeOptions;
    }


    public string Name { get; }
    public string? Description { get; }
    public bool IsReadonly { get; set; }
    public bool IsLocalized { get; }
    public bool IsRequired { get; }

    public NoxType Type { get; }
    public AreaTypeOptions? AreaTypeOptions { get; }
    public AutoNumberTypeOptions? AutoNumberTypeOptions { get; }
    public LengthTypeOptions? LengthTypeOptions { get; }
    public MarkdownTypeOptions? MarkdownTypeOptions { get; }
    public MoneyTypeOptions? MoneyTypeOptions { get; }
    public NuidTypeOptions? NuidTypeOptions { get; }
    public NumberTypeOptions? NumberTypeOptions { get; }
    public PercentageTypeOptions? PercentageTypeOptions { get; }
    public ReferenceNumberTypeOptions? ReferenceNumberTypeOptions { get; }
    public TemperatureTypeOptions? TemperatureTypeOptions { get; }
    public TextTypeOptions? TextTypeOptions { get; }
    public UserTypeOptions? UserTypeOptions { get; }
    public VolumeTypeOptions? VolumeTypeOptions { get; }
    public WeightTypeOptions? WeightTypeOptions { get; }
    public DistanceTypeOptions? DistanceTypeOptions { get; }
    public FormulaTypeOptions? FormulaTypeOptions { get; }
}