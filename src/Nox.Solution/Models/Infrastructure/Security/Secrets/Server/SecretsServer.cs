using Json.Schema.Generation;

namespace Nox.Solution
{
    [Title("The definition namespace for the secrets server used in a Nox solution.")]
    [Description("Specify properties pertinent to the secrets server here. Examples include name, serverUri, Port, connection credentials and provider")]
    [AdditionalProperties(false)]
    public class SecretsServer : ServerBase
    {
        [Required]
        [Title("The secrets server provider.")]
        [Description("The provider used for this secrets server. Examples include AzureKeyVault, AwsKeyManagementService and HashicorpVault.")]
        [AdditionalProperties(false)]
        public SecretsServerProvider? Provider { get; internal set; } = SecretsServerProvider.AzureKeyVault;
    }
}