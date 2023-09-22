namespace Nox
{
    public enum MessageBrokerProvider

    {
        RabbitMq,
        AzureServiceBus,
        AmazonSqs,
        InMemory
    }
    
    public static class MessagingServerProviderHelpers
    {
        public static string GetProviderScheme(MessageBrokerProvider provider)
        {
            switch (provider)
            {
                case MessageBrokerProvider.RabbitMq:
                    return "rabbitmq";
                case MessageBrokerProvider.AzureServiceBus:
                    return "sb";
                default:
                    return "";
            }
        }
    }
}
