namespace Nox.Secrets.Abstractions;

public interface ISecretsProvider
{
    Task<IReadOnlyDictionary<string, string?>> GetSecretsAsync(string[] keys);
    IReadOnlyDictionary<string, string?>? GetSecrets(string[] keys);
}