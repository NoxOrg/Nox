using System.Collections.Generic;
using Nox.Yaml.Attributes;

namespace Nox.Solution;

[GenerateJsonSchema]
[Title("Definition namespace for attributes describing the transformation of an integration integration.")]
[Description("This section details integration transformation attributes like transformType and mapping among other.")]
[AdditionalProperties(false)]
public class IntegrationTransform
{
    [Required]
    [Title("The type of transformation.")]
    [Description("Specify the type of transformation. Options include default, customCode and customMap.")]
    public IntegrationTransformType Type { get; internal set; } = IntegrationTransformType.Default;
    
    [Title("The custom mapping to use for the transformation.")]
    [Description("Specify the mapping to use for the transformation.")]
    public IReadOnlyDictionary<string, IntegrationTransformMap>? Mapping { get; internal set; }
}