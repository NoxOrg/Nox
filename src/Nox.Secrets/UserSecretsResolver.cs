using System.Reflection;
using Microsoft.Extensions.Configuration;
using Nox.Secrets.Abstractions;

namespace Nox.Secrets;

public class UserSecretsResolver: ISecretsResolver
{
    private readonly Assembly _executingAssembly;
    
    public UserSecretsResolver(Assembly executingAssembly)
    {
        _executingAssembly = executingAssembly;
    }

    public IReadOnlyDictionary<string, string?> Resolve(IReadOnlyList<string> keys)
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

        return result;
    }
}