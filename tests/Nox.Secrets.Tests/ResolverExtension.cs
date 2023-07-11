using System.Reflection;
using Nox.Abstractions;
using Nox.Secrets.Abstractions;
using Nox.Solution;

namespace Nox.Secrets.Tests;

public static class ResolverExtension
{
    public static void ConfigureForTest(this INoxSecretsResolver resolver)
    {
        var secretsConfig = new Solution.Secrets
        {
            OrganizationSecretsServer = new SecretsServer
            {
                Name = "org-vault",
                Provider = SecretsServerProvider.HashicorpVault,
                ServerUri = "http://localhost:8300",
                Password = "root",
                ValidFor = new SecretsValidFor
                {
                    Seconds = 30
                }    
            },
            SolutionSecretsServer = new SecretsServer
            {
                Name = "sln-vault",
                Provider = SecretsServerProvider.HashicorpVault,
                ServerUri = "http://localhost:8300",
                Password = "root",
                ValidFor = new SecretsValidFor
                {
                    Seconds = 30
                }
            }
        };
        resolver.Configure(secretsConfig, Assembly.GetCallingAssembly());
    }
}