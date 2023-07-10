using System.Reflection;
using Microsoft.Extensions.Configuration;
using Nox.Secrets.Abstractions;
using Nox.Secrets.Helpers;

namespace Nox.Secrets.Providers;

public class UserSecretsProvider: ISecretsProvider
{
    private readonly Assembly _executingAssembly;
    
    public UserSecretsProvider(Assembly executingAssembly)
    {
        _executingAssembly = executingAssembly;
    }

    public Task<IReadOnlyDictionary<string, string?>> GetSecretsAsync(string[] keys)
    {
        throw new Exception("Synchronous 'GetSecrets' must be used for user secrets.");
    }

    public IReadOnlyDictionary<string, string?>? GetSecrets(string[] keys)
    {
        var configuration = new ConfigurationBuilder()
            .AddUserSecrets(_executingAssembly)
            .Build();

        var result = new Dictionary<string, string?>();
        foreach (var key in keys)
        {
            var secretValue = configuration[key.ToFlattenedKey("user").Replace('.', ':')]; 
            if (!string.IsNullOrWhiteSpace(secretValue)) result.Add(key, secretValue);
            if (result.Any()) return result;
        }

        return null;
    }
}