using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nox.Types.EntityFramework.Abstractions;
using TestWebApp.Infrastructure.Persistence;

namespace Nox.Integration.Tests.Fixtures;

public abstract class NoxTestDataContextFixtureBase : INoxTestDataContextFixture
{
    protected DbContext _dbContext = default!;

    public DbContext DataContext
    {
        get
        {
            if (_dbContext == null)
            {
                RefreshDbContext();
            }

            return _dbContext!;
        }
    }

    public void RefreshDbContext()
    {
        var services = new ServiceCollection();

        services.AddNox(
               null,
           (noxOptions) =>
           {
               noxOptions.WithoutMessagingTransactionalOutbox();
           }, null);

        var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(INoxDatabaseProvider));
        if (descriptor != null)
        {
            services.Remove(descriptor);
        }
        services.AddSingleton(sp =>
        {
            var configurations = sp.GetServices<INoxTypeDatabaseConfigurator>();
            return GetDatabaseProvider(configurations);
        });

        var serviceProvider = services.BuildServiceProvider();
        _dbContext = serviceProvider.GetRequiredService<TestWebAppDbContext>();
    }

    protected abstract INoxDatabaseProvider GetDatabaseProvider(IEnumerable<INoxTypeDatabaseConfigurator> configurators);
}