using System.Reflection;
using Microsoft.Extensions.Configuration;
using Nox.Secrets.Abstractions;

namespace Nox.Secrets.Providers;

public class UserSecretProvider: ISecretProvider
{
    private readonly Assembly _executingAssembly;
    
    public UserSecretProvider(Assembly executingAssembly)
    {
        _executingAssembly = executingAssembly;
    }

    public int Precedence => 2;

    public Task<IList<KeyValuePair<string, string>>?> GetSecretsAsync(string[] keys)
    {
        throw new Exception("Synchronous 'GetSecrets' must be used for user secrets.");
    }

    public IList<KeyValuePair<string, string>>? GetSecrets(string[] keys)
    {
        var result = new List<KeyValuePair<string, string>>();
        var configuration = new ConfigurationBuilder()
            .AddUserSecrets(_executingAssembly)
            .Build();
        foreach (var key in keys)
        {
            var secret = configuration[key.Replace('.', ':')];
            if (secret != null) result.Add(new KeyValuePair<string, string>(key, secret));
        }
        return result;
    }
}