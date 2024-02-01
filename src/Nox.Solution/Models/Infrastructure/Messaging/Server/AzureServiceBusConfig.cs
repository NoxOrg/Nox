using Nox.Yaml;
using Nox.Yaml.Attributes;
using Nox.Yaml.Validation;

namespace Nox.Solution;

[GenerateJsonSchema()]
[Title("Azure Service Bus server configuration.")]
[Description("Configuration to create a valid Azure Service Bus Connection, for example: sb://your-servicebus-name.servicebus.windows.net/;SharedAccessKeyName=YourKeyName;SharedAccessKey=YourKey;")]
[AdditionalProperties(false)]
public class AzureServiceBusConfig : YamlConfigNode<NoxSolution, MessagingServer>
{
    [Required]
    [Title("The endpoint to be used for connecting to the Service Bus namespace.")]
    [Description("Example sb://your-servicebus-name.servicebus.windows.net/")]
    public string Endpoint { get; internal set; } = null!;

    [Title("The actual security key associated with the shared access key name used to establish secure communication.")]
    public string SharedAccessKey { get; internal set; } = null!;

    [Title("The name of the shared access key that provides security credentials for authentication.")]
    public string SharedAccessKeyName { get; internal set; } = null!;

    public override ValidationResult Validate(NoxSolution topNode, MessagingServer parentNode, string yamlPath)
    {
        var validationResult = base.Validate(topNode, parentNode, yamlPath);

        if ((!string.IsNullOrWhiteSpace(SharedAccessKey) && string.IsNullOrWhiteSpace(SharedAccessKeyName)) 
            || (string.IsNullOrWhiteSpace(SharedAccessKey) && !string.IsNullOrWhiteSpace(SharedAccessKeyName)))
        {
            validationResult.Errors.Add(
                new ValidationFailure(nameof(AzureServiceBusConfig), $"Either both fields {nameof(SharedAccessKey)} and {nameof(SharedAccessKeyName)} must be set, or none of them should be set."));
        }

        return validationResult;
    }
}