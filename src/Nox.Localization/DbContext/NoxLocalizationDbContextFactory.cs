using Nox.Abstractions;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.Enums;

namespace Nox.Localization;

public class NoxLocalizationDbContextFactory: INoxLocalizationDbContextFactory
{
    private readonly IEnumerable<INoxDatabaseProvider> _databaseProviders;
    private readonly INoxClientAssemblyProvider _clientAssemblyProvider;

    public NoxLocalizationDbContextFactory(
        IEnumerable<INoxDatabaseProvider> databaseProviders,
        INoxClientAssemblyProvider clientAssemblyProvider)
    {
        _databaseProviders = databaseProviders;
        _clientAssemblyProvider = clientAssemblyProvider;
    }
    
    public NoxLocalizationDbContext CreateContext()
    {
        return new NoxLocalizationDbContext(NoxSolutionBuilder.Instance!, _databaseProviders);
    }

    
}