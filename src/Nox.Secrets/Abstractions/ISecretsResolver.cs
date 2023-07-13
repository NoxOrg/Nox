namespace Nox.Secrets.Abstractions;

public interface ISecretsResolver
{
    IReadOnlyDictionary<string, string?> Resolve(string[] keys);
}