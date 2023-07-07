using System.Reflection;
using Microsoft.Extensions.Configuration;
using Nox.Secrets.Abstractions;
using Nox.Secrets.Helpers;

namespace Nox.Secrets.Resolvers;

public class UserSecretResolver: ISecretResolver
{
    private readonly Assembly _executingAssembly;
    
    public UserSecretResolver(Assembly executingAssembly)
    {
        _executingAssembly = executingAssembly;
    }

    public int Precedence => 2;
    public Task ResolveAsync(IDictionary<string, string?> secrets)
    {
        throw new Exception("Synchronous 'Resolve' must be used for user secrets.");
    }

    public void Resolve(IDictionary<string, string?> secrets)
    {
        var configuration = new ConfigurationBuilder()
            .AddUserSecrets(_executingAssembly)
            .Build();
        foreach (var key in secrets.Keys)
        {
            secrets[key] = configuration[key.ToFlattenedKey("user").Replace('.', ':')];
        }
    }
}