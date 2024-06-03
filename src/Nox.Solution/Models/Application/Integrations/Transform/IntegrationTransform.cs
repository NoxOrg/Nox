using System.Collections.Generic;
using Nox.Yaml.Attributes;

namespace Nox.Solution;

[GenerateJsonSchema]
[Title("Definition namespace for attributes describing the transformation of an integration integration.")]
[Description("This section details integration transformation attributes like transformType and mapping among other.")]
[AdditionalProperties(false)]
public class IntegrationTransform
{
    [Title("The custom mapping to use for the transformation.")]
    [Description("Specify the mapping to use for the transformation.")]
    public IReadOnlyList<IntegrationMapping>? Mapping { get; internal set; }
}