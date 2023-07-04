using Json.Schema.Generation;

namespace Nox.Solution.Events;

[Title("Defines an event that can be raised on the entity.")]
[Description("Defines a n event that can be raised on the entity. An event is immutable and doesn't return a value.")]
[AdditionalProperties(false)]
public class DomainEvent: NoxComplexTypeDefinition
{
    
}