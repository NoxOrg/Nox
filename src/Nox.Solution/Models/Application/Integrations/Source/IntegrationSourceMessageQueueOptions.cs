using System.Collections.Generic;
using Nox.Types;
using Nox.Yaml.Attributes;

namespace Nox.Solution
{
    [Title("Definition namespace for a Message Queue integration source.")]
    [Description("This section specified attributes related to an integration source of type Message Queue. Attributes include the name of the source queue or topic.")]
    [AdditionalProperties(false)]
    public class IntegrationSourceMessageQueueOptions
    {
        [Required]
        [Title("The source name.")]
        [Description("The name of the queue or topic subscription from which messages will be consumed.")]
        public string SourceName { get; set; } = null!;
        
        [Required]
        [Title("The attributes of the source message.")]
        [Description("One or more attributes describing the composition of the source message.")]
        [AdditionalProperties(false)]
        public IReadOnlyList<NoxSimpleTypeDefinition> MessageAttributes { get; internal set; } = new List<NoxSimpleTypeDefinition>();
    }
}