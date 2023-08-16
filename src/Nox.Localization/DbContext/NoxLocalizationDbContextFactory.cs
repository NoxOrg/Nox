using Nox.Abstractions;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.Enums;

namespace Nox.Localization;

public class NoxLocalizationDbContextFactory: INoxLocalizationDbContextFactory
{
    private readonly INoxDatabaseProvider _databaseProvider;
    private readonly INoxClientAssemblyProvider _clientAssemblyProvider;

    public NoxLocalizationDbContextFactory(
        IEnumerable<INoxDatabaseProvider> databaseProviders,
        INoxClientAssemblyProvider clientAssemblyProvider)
    {
        _databaseProvider = databaseProviders.Single(p => p.StoreType == NoxDataStoreType.LocalizationStore);
        _clientAssemblyProvider = clientAssemblyProvider;
    }
    
    public NoxLocalizationDbContext CreateContext()
    {
        return new NoxLocalizationDbContext(_databaseProvider, _clientAssemblyProvider);
    }

    
}