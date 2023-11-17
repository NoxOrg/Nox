using Nox.Yaml.Attributes;

namespace Nox.Solution;

[GenerateJsonSchema]
[AdditionalProperties(false)]
public class MessagingServer 
{
    [Required]
    [Pattern(@"^[^\s]*$")]
    [Title("The unique name of this server component in the solution.")]
    [Description("The name of this server component in the solution. The name must be unique in the solution configuration")]
    public string Name { get; internal set; } = null!;

    [Required]
    [Title("The messaging server provider.")]
    [Description("The provider used for this messaging server. Examples Azure ServiceBus and InMemory.")]    
    public MessageBrokerProvider Provider { get; internal set; } = MessageBrokerProvider.InMemory;

    [IfEquals(nameof(Provider), MessageBrokerProvider.AzureServiceBus)]
    [Title("Azure Service Bus Configuration, required if Provider is AzureServiceBus.")]
    public AzureServiceBusConfig? AzureServiceBusConfig { get; set; }

    internal bool ApplyDefaults()
    {
        return true;
    }
}
