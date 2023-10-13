using System.Collections.Generic;
using Nox.Types;
using Nox.Types.Schema;

namespace Nox.Solution;

[Title("Definition namespace for a Message Queue integration target.")]
[Description("This section specified attributes related to an integration target of type Message Queue. Attributes include the name of the target queue or topic.")]
[AdditionalProperties(false)]
public class IntegrationTargetMessageQueueOptions
{
    [Required]
    [Title("The target name.")]
    [Description("The name of the queue, topic or subscription to which messages will be sent.")]
    public string TargetName { get; set; } = null!;
    
    [Required]
    [Title("The attributes of the target message.")]
    [Description("One or more attributes describing the composition of the target message.")]
    [AdditionalProperties(false)]
    public IReadOnlyList<NoxSimpleTypeDefinition> MessageAttributes { get; internal set; } = new List<NoxSimpleTypeDefinition>();
}