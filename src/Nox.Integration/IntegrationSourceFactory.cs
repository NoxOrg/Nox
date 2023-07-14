using Nox.Integration.Abstractions;

namespace Nox.Integration;

public class IntegrationSourceFactory: IIntegrationSourceFactory
{
    private readonly Func<IEnumerable<ISource>> _factory;

    public IntegrationSourceFactory(Func<IEnumerable<ISource>> factory)
    {
        _factory = factory;
    }

    public ISource Create(string name)
    {
        var sources = _factory();
        var source = sources.First(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        return source;
    }
}