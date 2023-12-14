using Nox.Yaml;
using Nox.Yaml.Attributes;

namespace Nox.Solution;

[GenerateJsonSchema]
[Title("The definition namespace for presentation components pertaining to a Nox solution.")]
[Description("Define components pertinent to solution API and UI here.Contains all settings affecting the presentation of the solution.")]
[AdditionalProperties(false)]
public class Presentation : YamlConfigNode<NoxSolution,NoxSolution>
{
    public ApiConfiguration ApiConfiguration { get; set; } = new();

}
