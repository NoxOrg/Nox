namespace Nox.Secrets.Abstractions;

public interface ISecretsResolver
{
    IReadOnlyDictionary<string, string?> Resolve(IReadOnlyList<string> keys);
}