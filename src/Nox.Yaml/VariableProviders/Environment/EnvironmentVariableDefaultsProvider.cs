namespace Nox.Yaml.VariableProviders.Environment;

public sealed class EnvironmentVariableDefaultsProvider<T> where T : class, new()
{

    private readonly Func<T, IReadOnlyDictionary<string, object>> _valueProvider;

    public EnvironmentVariableDefaultsProvider(Func<T, IReadOnlyDictionary<string, object>> valueProvider)
    {
        _valueProvider = valueProvider;
    }

    public IReadOnlyDictionary<string, object> Resolve(T objectInstance)
        => _valueProvider(objectInstance);

}