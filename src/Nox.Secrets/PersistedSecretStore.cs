using Microsoft.AspNetCore.DataProtection;
using Nox.Secrets.Abstractions;
using Nox.Solution.Constants;
using File = System.IO.File;

namespace Nox.Secrets;

public class PersistedSecretStore: IPersistedSecretStore
{
    private readonly IDataProtector _protector;
    private const string ProtectorPurpose = "nox-secrets";

    public PersistedSecretStore(
        IDataProtectionProvider provider)
    {
        _protector = provider.CreateProtector(ProtectorPurpose);
    }

    public void Save(string key, string secret)
    {
        File.WriteAllText(GetSecretPath(key), _protector.Protect(secret));
    }

    public string? Load(string key, TimeSpan? validFor = null)
    {
        validFor ??= new TimeSpan(0, 10, 0);

        var secretPath = GetSecretPath(key);
        
        if (!File.Exists(secretPath))
        {
            return null;
        }

        var fileInfo = new FileInfo(secretPath);
        
        if (fileInfo.CreationTime.Add(validFor.Value) < DateTime.Now)
        {
            File.Delete(secretPath);
            return null;
        }

        var content = File.ReadAllText(secretPath);
        return _protector.Unprotect(content);
    }

    private string GetSecretPath(string key)
    {
        var path = WellKnownPaths.SecretsCachePath;
        Directory.CreateDirectory(path);
        //Todo implement once Nuid Nox type is available
        //var keyNuid = Nuid.From(key);
        //path = Path.Combine(path, $".{keyNuid}");

        return Path.Combine(path, $".{key}");
    }
}