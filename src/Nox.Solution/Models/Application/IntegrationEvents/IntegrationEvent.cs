using Nox.Yaml.Attributes;
using Nox.Types;

namespace Nox.Solution;

[GenerateJsonSchema]
public class IntegrationEvent: NoxComplexTypeDefinition
{
    [Required]
    [Title("The Domain Context of the event. Contains no spaces.")]
    [Description("Domain context should have one of this value types: EntityName | BussinessProcessName | BoundedContext. Used to define the type in the Cloud events. Example: {Solution.PlatformId}.{Solution.Name}.{DomainContext}.v{Solution.Version}.{eventName}.")]
    [Pattern(Nox.Yaml.Constants.StringWithNoSpacesRegex)]
    public string DomainContext { get; internal set; } = null!;
}