namespace Nox.Secrets.Abstractions;

public interface IPersistedSecretStore
{
    void Save(string key, string secret);

    string? Load(string key, TimeSpan? validFor = null);
    
#if NET7_0    
    Task SaveAsync(string key, string secret);
    Task<string?> LoadAsync(string key, TimeSpan? validFor = null);
#endif
}