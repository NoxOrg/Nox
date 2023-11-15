using Nox.Yaml.Attributes;
using Nox.Yaml.Tests.TestDesigns.Nox.Types.TypeDefinitions;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Models;

[GenerateJsonSchema("dto")]
public class IntegrationEvent : NoxComplexTypeDefinition
{
    [Required]
    [Title("The trait of the event. Contains no spaces.")]
    [Description("Assign a trait to the event that defines it's scope. PascalCase recommended.")]
    [Pattern(@"^[^\s]*$")]
    public string Trait { get; internal set; } = null!;
}