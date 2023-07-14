using Nox.Integration.Abstractions;
using Nox.Solution;

namespace Nox.Integration;

public class IntegrationSourceFactory: IIntegrationSourceFactory
{
    private readonly Func<IEnumerable<ISource>> _factory;
    private readonly Solution.Solution _solution;

    public IntegrationSourceFactory(Func<IEnumerable<ISource>> factory, Solution.Solution solution)
    {
        _factory = factory;
        _solution = solution;
    }

    public ISource Create(string name)
    {
        var sources = _factory();
        var source = sources.First(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        return source;
    }
}