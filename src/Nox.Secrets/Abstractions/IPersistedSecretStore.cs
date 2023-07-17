namespace Nox.Secrets.Abstractions;

public interface IPersistedSecretStore
{
    void Save(string key, string secret);

    string? Load(string key, TimeSpan? validFor = null);
}