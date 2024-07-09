using Nox.Yaml.Attributes;

namespace Nox.Solution;

[GenerateJsonSchema]
[Title("Definition namespace for attributes describing the transformation mapping of a field.")]
[Description("This section details integration transformation mapping attributes like sourceName, sourceType, targetType.")]
[AdditionalProperties(false)]
public class IntegrationMapping
{
    [Title("The attributes of the source field. If omitted this field will be regarded as a calculated value.")]
    [Description("Specify the attributes of the source field.")]
    public IntegrationMappingField? Source { get; set; } = null!;

    [Title("The attributes of the target field.")]
    [Description("Specify the attributes of the target field.")]
    public IntegrationMappingField? Target { get; set; } = null!;
    
    [Title("Is the field required?")]
    [Description("Specify whether the field is required.")]
    public bool IsRequired { get; set; } = false;
}