using Nox.Types;
using Nox.Yaml.Attributes;

namespace Nox.Solution.Events;

[GenerateJsonSchema]
public class DomainEvent
{
    [Required]
    [Title("Event name")]
    [Description("Assign a descriptive name to the event. Should be a singular noun and be unique within a collection of events. PascalCase recommended.")]
    public string Name { get; internal set; } = null!;

    [Required]
    [Title("Event description")]
    [Description("A descriptive phrase that explains the nature and function of this event within a collection.")]
    public string? Description { get; internal set; }
}