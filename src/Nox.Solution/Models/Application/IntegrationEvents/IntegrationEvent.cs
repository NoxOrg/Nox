using Nox.Yaml.Attributes;
using Nox.Types;

namespace Nox.Solution;

[GenerateJsonSchema]
public class IntegrationEvent: NoxComplexTypeDefinition
{
    [Required]
    [Title("The trait of the event. Contains no spaces.")]
    [Description("Assign a trait to the event that defines it's scope. PascalCase recommended.")]
    [Pattern(Nox.Yaml.Constants.StringWithNoSpacesRegex)]
    public string Trait { get; internal set; } = null!;
}