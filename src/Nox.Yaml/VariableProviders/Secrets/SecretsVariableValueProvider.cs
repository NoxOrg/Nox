namespace Nox.Yaml.VariableProviders.Environment;

public sealed class SecretsVariableValueProvider<T> where T : class, new()
{
 
    private readonly Func<T, IReadOnlyList<string>, IReadOnlyDictionary<string, string>> _valueProvider;

    public SecretsVariableValueProvider(Func<T, IReadOnlyList<string>, IReadOnlyDictionary<string, string>> valueProvider)
    {
        _valueProvider = valueProvider;
    }

    public IReadOnlyDictionary<string, string> Resolve(T objectInstance, IReadOnlyList<string> secretVariables) 
        => _valueProvider(objectInstance, secretVariables);

}