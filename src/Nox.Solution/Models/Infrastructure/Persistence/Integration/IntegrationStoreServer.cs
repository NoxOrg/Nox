using Nox.Yaml.Attributes;

namespace Nox.Solution;

[GenerateJsonSchema]
public class IntegrationStoreServer : ServerBase
{
    [Required]
    [Title("The integration store provider.")]
    [Description("The provider used for the integration data store. Examples include SqlServer, Postgres and others.")]
    public IntegrationStoreProvider Provider { get; internal set; } = IntegrationStoreProvider.SqlServer;
}