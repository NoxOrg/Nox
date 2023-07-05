using Json.Schema.Generation;
using Nox.Solution.Builders;

namespace Nox.Solution
{ 
    public class MessagingServer : ServerBase
    {
        [Required]
        [Title("The messaging server provider.")]
        [Description("The provider used for this messaging server. Examples include RabbitMQ, Azure ServiceBus, Amazon SQS and InMemory.")]
        [AdditionalProperties(false)]
        public MessagingServerProvider Provider { get; internal set; } = MessagingServerProvider.InMemory;
        
        internal bool ApplyDefaults()
        {
            switch (Provider)
            {
                case MessagingServerProvider.RabbitMq:
                case MessagingServerProvider.AzureServiceBus:
                    var builder = new NoxUriBuilder(this, MessagingServerProviderHelpers.GetProviderScheme(Provider), "infrastructure, messaging, integrationEventServer");
                    ServerUri = builder.Uri!.ToString();
                    break;
                case MessagingServerProvider.AmazonSqs:
                    // ServerUri must contain explicit arn e.g. arn:aws:sqs:region:account-id:queue-name
                    break;
                case MessagingServerProvider.InMemory:
                    ServerUri = "inmemory";
                    break;
            }
            
            return true;
        }
    }
}
