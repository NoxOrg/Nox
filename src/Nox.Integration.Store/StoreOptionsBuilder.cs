using Microsoft.Extensions.DependencyInjection;
using Nox.Solution;

namespace Nox.Integration.Store;

public class StoreOptionsBuilder
{
    public IntegrationDatabaseServer ServerConfiguration { get; }
    public IServiceCollection ServiceCollection { get; }

    public StoreOptionsBuilder(IServiceCollection serviceCollection, IntegrationDatabaseServer serverConfig)
    {
        ServerConfiguration = serverConfig;
        ServiceCollection = serviceCollection;
    }
}