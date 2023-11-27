
using Nox.Yaml.Attributes;

namespace Nox.Solution;

[GenerateJsonSchema]
[Title("The definition namespace for messaging settings pertaining to a Nox solution.")]
[Description("Defines settings pertinent to solution messaging here. These include IntegrationEventServer provider (RabbitMQ, Azure ServiceBus, Amazon SQS etc) and additional server connection details.")]
[AdditionalProperties(false)]
public class Messaging
{
    [Required]
    // These descriptors should be moved to the class when the generator is fixed
    [Title("Details pertaining to the IntegrationEventServer settings in a Nox solution.")]
    [Description("Defines settings pertinent to an IntegrationEventServer here. These include provider (RabbitMQ, Azure ServiceBus, Amazon SQS etc), connection details as well as internal default deployment settings.")]
    [AdditionalProperties(false)]
    public MessagingServer? IntegrationEventServer { get; internal set; } = new();
}
