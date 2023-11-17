using Nox.Yaml.Attributes;

namespace Nox.Solution;

[GenerateJsonSchema()]
[Title("Azure Service Bus server configuration.")]
[Description("Configuration to create a valid Azure Service Bus Connection, for example: sb://your-servicebus-name.servicebus.windows.net/;SharedAccessKeyName=YourKeyName;SharedAccessKey=YourKey;")]
[AdditionalProperties(false)]
public class AzureServiceBusConfig
{
    [Required]        
    [Title("The endpoint to be used for connecting to the Service Bus namespace.")]
    [Description("Example sb://your-servicebus-name.servicebus.windows.net/")]
    public string Endpoint { get; internal set; } = null!;

    [Required]
    [Title("The actual security key associated with the shared access key name used to establish secure communication.")]        
    public string SharedAccessKey { get; internal set; } = null!;

    [Required]
    [Title("The name of the shared access key that provides security credentials for authentication.")]
    public string SharedAccessKeyName { get; internal set; } = null!;
}