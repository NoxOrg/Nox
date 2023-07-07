using Nox.Solution;

namespace Nox.Secrets.Tests;

public class MockSecretsServer : SecretsServer
{
    public new string Name { get; set; } = null!;
    public new SecretsServerProvider? Provider { get; set; } = SecretsServerProvider.AzureKeyVault;
    public new string ServerUri { get; set; } = null!;
    public new MockSecretsValidFor? ValidFor { get; set; }
}