using Nox.Yaml.Attributes;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Models;

[GenerateJsonSchema]
[AdditionalProperties(false)]

public class Messaging
{
    // These descriptors should be moved to the class when the generator is fixed
    [Required]
    [Title("Details pertaining to the IntegrationEventServer settings in a Nox solution.")]
    [Description("Defines settings pertinent to an IntegrationEventServer here. These include provider (RabbitMQ, Azure ServiceBus, Amazon SQS etc), connection details as well as internal default deployment settings.")]
    [AdditionalProperties(false)]
    public MessagingServer? IntegrationEventServer { get; internal set; } = new();
}
