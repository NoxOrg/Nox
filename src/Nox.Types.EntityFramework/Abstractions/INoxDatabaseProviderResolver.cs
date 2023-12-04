using Nox.Types.EntityFramework.Enums;

namespace Nox.Types.EntityFramework.Abstractions;

public interface INoxDatabaseProviderResolver
{
    INoxDatabaseProvider Resolve(NoxDataStoreType storeType);
}