using Nox.Types.Schema;
using Nox.Solution.Builders;

namespace Nox.Solution;

[GenerateJsonSchema]
public class MessagingServer : ServerBase
{
    [Required]
    [Title("The messaging server provider.")]
    [Description("The provider used for this messaging server. Examples include RabbitMQ, Azure ServiceBus, Amazon SQS and InMemory.")]
    [AdditionalProperties(false)]
    public MessageBrokerProvider Provider { get; internal set; } = MessageBrokerProvider.InMemory;
    
    internal bool ApplyDefaults()
    {
        //switch (Provider)
        //{
        //    case MessageBrokerProvider.RabbitMq:
        //    case MessageBrokerProvider.AzureServiceBus:
        //        var builder = new NoxUriBuilder(this, MessagingServerProviderHelpers.GetProviderScheme(Provider), "infrastructure, messaging, integrationEventServer");
        //        ServerUri = builder.Uri!.ToString();
        //        break;
        //    case MessageBrokerProvider.AmazonSqs:
        //        // ServerUri must contain explicit arn e.g. arn:aws:sqs:region:account-id:queue-name
        //        break;
        //    case MessageBrokerProvider.InMemory:
        //        ServerUri = "inmemory";
        //        break;
        //}

        return true;
    }
}
