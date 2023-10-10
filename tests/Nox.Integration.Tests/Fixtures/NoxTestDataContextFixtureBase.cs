using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nox.Types.EntityFramework.Abstractions;
using TestWebApp.Infrastructure.Persistence;

namespace Nox.Integration.Tests.Fixtures;

public abstract class NoxTestDataContextFixtureBase : INoxTestDataContextFixture
{
    protected DbContext _dbContext = default!;
    private readonly IServiceProvider _serviceProvider;

    protected NoxTestDataContextFixtureBase()
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

        _serviceProvider = services.BuildServiceProvider();
    }

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
        var scope = _serviceProvider.CreateScope();
        _dbContext = scope.ServiceProvider.GetRequiredService<TestWebAppDbContext>();
    }

    protected abstract INoxDatabaseProvider GetDatabaseProvider(IEnumerable<INoxTypeDatabaseConfigurator> configurators);
}