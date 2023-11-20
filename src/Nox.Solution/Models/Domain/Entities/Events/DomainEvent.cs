using Nox.Types;
using Nox.Yaml.Attributes;

namespace Nox.Solution.Events;

[GenerateJsonSchema]
public class DomainEvent: NoxComplexTypeDefinition
{
    [Title("Wether or not to also raise this as an application event.")]
    [Description("Will raise this event both as an integration and application event")]
    public bool RaiseApplicationEvent { get; set; } = false;
}