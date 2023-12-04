using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.Enums;

namespace Nox.Types.EntityFramework;

public class NoxDatabaseProviderResolver: INoxDatabaseProviderResolver
{
    private readonly IEnumerable<INoxDatabaseProvider> _providers;

    public NoxDatabaseProviderResolver(IEnumerable<INoxDatabaseProvider> providers)
    {
        _providers = providers;
    }
    
    public INoxDatabaseProvider Resolve(NoxDataStoreType storeType)
    {
        return _providers.Single(p => p.StoreType == storeType);
    }
}