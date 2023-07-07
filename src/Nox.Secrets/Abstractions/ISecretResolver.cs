namespace Nox.Secrets.Abstractions;

public interface ISecretResolver
{
    int Precedence { get; }
    Task ResolveAsync(IDictionary<string, string?> secrets);
    void Resolve(IDictionary<string, string?> secrets);
}